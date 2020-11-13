
import UIKit
import NMAKit
import Foundation
import GameplayKit

/*
* **************************************************
* CODE ADAPTED FROM
* Title: gamekitPath.swift
* Author: Zanetello, F.
* Date: 2017
* Available at: https://gist.github.com/zntfdr/c93fc2863ac0a847a90865564ca22121
* **************************************************
*/
class Dijkstra {
    var routes: [MapRoute]
    var nodes: [MyNode] = []
    var standard: Bool = false
    
    
    init(routes: [MapRoute]) {
        self.routes = routes
        setNodes(routes: routes)
    }
    
    init (routes:[MapRoute], standardDijkstra: Bool) {
        self.routes = routes
        self.standard = standardDijkstra
        
        setNodes(routes: routes)
    }
    
    
    /** Set nodes for either end of routes */
    private func setNodes(routes: [MapRoute]) {
        
        for route in routes {
            let coords = route.getCoords()
            let coord1: NMAGeoCoordinates = coords[0] as! NMAGeoCoordinates
            let coord2: NMAGeoCoordinates = coords[1] as! NMAGeoCoordinates
            
            var node1: MyNode
            var node2: MyNode
            
            var node1Exists = false
            var node2Exists = false
            
            
            // Check if route coordinates already added as a node
            for node in nodes {
                // If both nodes exist
                if (node1Exists && node2Exists) {
                    break
                }
                
                // If either end of route's coordinates already in list
                if (node.coord.longitude == coord1.longitude && node.coord.longitude == coord1.latitude) {
                    node1Exists = true
                }
                else if (node.coord.longitude == coord2.longitude && node.coord.latitude == coord2.latitude) {
                    node2Exists = true
                }
            }
            
            
            // If node1 not already in list
            if (!node1Exists) {
                node1 = MyNode(coord: coord1)
                nodes.append(node1)
            }
            
            
            // If node2 not alreay in list
            if (!node2Exists) {
                node2 = MyNode(coord: coord2)
                nodes.append(node2)
            }
        }
        
        myGraph.add(nodes)
        setConnections(routes: routes)
    }

    
    /** Find node from list */
    private func getNode(coord: NMAGeoCoordinates) -> MyNode? {
        
        // Check if any node has the same coords
        for node in nodes {
            if (node.coord.longitude == coord.longitude && node.coord.latitude == coord.latitude) {
                return node
            }
        }
        
        return nil
    }

    
    /** Create link between nodes */
    private func setConnections(routes: [MapRoute]) {
        
        for route in routes {
            let coords = route.getCoords()
            let coord1: NMAGeoCoordinates = coords[0] as! NMAGeoCoordinates
            let coord2: NMAGeoCoordinates = coords[1] as! NMAGeoCoordinates
            
            // If using standard Dijkstra's or indoor version with other people adding delay
            var delay: Float = 0
            if (!standard) {
                delay = (Float(numPeopleOnRoute(coord1: coord1, coord2: coord2)) * 0.0001)
            }
            
            let weight = route.getWeight() + delay
            
            
            // Get nodes and add connection between the two
            if let node1 = getNode(coord: coord1) {
                if let node2 = getNode(coord: coord2) {
                    node1.addConnection(to: node2, bidirectional: true, weight: weight)
                    node2.addConnection(to: node1, bidirectional: true, weight: weight)
                }
                else {
                    // Error message
                    print("Node at \(coord2.longitude),\(coord2.latitude) doesn't exist")
                    return
                }
            }
            else {
                // Error message
                print("Node at \(coord1.longitude),\(coord1.latitude) doesn't exist")
                return
            }
        }
    }
    
    
    /** Count the number of people on this route */
    private func numPeopleOnRoute(coord1: NMAGeoCoordinates, coord2: NMAGeoCoordinates) -> Int {
        
        let deviceID = 0 // Testing value, would be real device ID
        
        var numPeopleOnRoute: Int = 0
        for person in Server.getUsers()! {
            
            // Ignore this device
            if (person.getDeviceID() == deviceID) {
                continue
            }
            
            // Find route person is on
            if let personOnRoute: MapRoute = IndoorMaps.findRoute(position: person.getLocation()!) {
                
                let routeCoords = personOnRoute.getCoords()
                let routeCoord1 = routeCoords[0] as! NMAGeoCoordinates
                let routeCoord2 = routeCoords[1] as! NMAGeoCoordinates
                
                // Check that route that person is on matches current route
                if ((routeCoord1.latitude == coord1.latitude && routeCoord1.longitude == coord1.longitude &&
                    routeCoord2.latitude == coord2.latitude && routeCoord2.longitude == coord2.longitude) ||
                    (routeCoord1.latitude == coord2.latitude && routeCoord1.longitude == coord2.longitude &&
                    routeCoord2.latitude == coord1.latitude && routeCoord2.longitude == coord1.longitude)) {
                    
                    numPeopleOnRoute += 1
                }
            }
            else {
                return 0
            }
        }
        
        return numPeopleOnRoute
    }

    
    /** Find the shortest path between the two points */
    public func getShortestPath(from: NMAGeoCoordinates, to: NMAGeoCoordinates) -> [MapRoute]? {
        
        // Get nodes at coordinates
        if let fromNode = getNode(coord: from) {
            if let toNode = getNode(coord: to) {
                
                // Calculate best path
                let path = myGraph.findPath(from: fromNode, to: toNode)
                
                return finalPath(path: path)
            }
            else {
                // Error message
                print("Node at \(to.longitude),\(to.latitude) doesn't exist")
                return nil
            }
        }
        else {
            // Error message
            print("Node at \(from.longitude),\(from.latitude) doesn't exist")
            return nil
        }
    }
    
    
    /** Find the total cost of a route */
    public func getTotalCost(from: NMAGeoCoordinates, to: NMAGeoCoordinates) -> Float {
        
        // Get nodes at coordinates
        if let fromNode = getNode(coord: from) {
            if let toNode = getNode(coord: to) {
                
                // Calculate best path
                let path = myGraph.findPath(from: fromNode, to: toNode)
                
                return getCost(for: path)
            }
            else {
                // Error message
                print("Node at \(to.longitude),\(to.latitude) doesn't exist")
                return 0
            }
        }
        else {
            // Error message
            print("Node at \(from.longitude),\(from.latitude) doesn't exist")
            return 0
        }
    }
    
    
    /** Create route of the final path */
    private func finalPath(path: [GKGraphNode]) -> [MapRoute] {
        
        let route: [NMAGeoCoordinates] = getPath(path)
        var finalPath: [MapRoute] = []
        
        // Create and add MapRoutes to array
        for i in 0..<(path.count-1) {
            let cost = path[i].cost(to: path[i + 1])
            finalPath.append(MapRoute.init(building: "", coord1: route[i], coord2: route[i + 1], weight: cost))
        }
        
        
        /* FOR TESTING */
        var totalPoepleOnRoute: Int = 0
        for path in finalPath {
            let coord1 = path.getCoords()[0] as! NMAGeoCoordinates
            let coord2 = path.getCoords()[1] as! NMAGeoCoordinates
            
            totalPoepleOnRoute += numPeopleOnRoute(coord1: coord1, coord2: coord2)
        }
        print("People on route: \(totalPoepleOnRoute)")
        
        
        return finalPath
    }
}


/*
 * **************************************************
 * CODE OBTAINED FROM
 * Title: gamekitPath.swift
 * Author: Zanetello, F.
 * Date: 2017
 * Available at: https://gist.github.com/zntfdr/c93fc2863ac0a847a90865564ca22121
 * **************************************************
 */
let myGraph = GKGraph()

class MyNode: GKGraphNode {
    let coord: NMAGeoCoordinates
    var travelCost: [GKGraphNode: Float] = [:]

    init(coord: NMAGeoCoordinates) {
        self.coord = coord
        super.init()
    }

    required init?(coder aDecoder: NSCoder) {
        self.coord = NMAGeoCoordinates()
        super.init()
    }

    override func cost(to node: GKGraphNode) -> Float {
        return travelCost[node] ?? 0
    }

    func addConnection(to node: GKGraphNode, bidirectional: Bool = true, weight: Float) {
        self.addConnections(to: [node], bidirectional: bidirectional)
        travelCost[node] = weight
        guard bidirectional else { return }
        (node as? MyNode)?.travelCost[self] = weight
    }
}


func getPath(_ path: [GKGraphNode]) -> [NMAGeoCoordinates] {
    var route: [NMAGeoCoordinates] = []
    
    path.flatMap({ $0 as? MyNode}).forEach { node in
        route.append(node.coord)
    }
    
    return route
}


func getCost(for path: [GKGraphNode]) -> Float {
    var total: Float = 0
    
    for i in 0..<(path.count-1) {
        let cost: Float = path[i].cost(to: path[i+1])
        if (!cost.isNaN) {
            total += cost
        }
    }
    
    return total
}

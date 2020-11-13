
import UIKit
import NMAKit
import Foundation


/*
 * **************************************************
 * CODE ADAPTED FROM
 * Title: map-objects-ios-swift
 * Author: HERE Technologies
 * Date: 2020
 * Available at: https://github.com/heremaps/here-ios-sdk-examples/tree/master/map-objects-ios-swift
 * **************************************************
 */
class IndoorRoute {
    
    @IBOutlet weak private var mapView: NMAMapView!
    private var geoBoxes : [NMAGeoBoundingBox?] = []
    private var geoLines : [NMAMapPolyline?] = []
    
    
    init(mapView: NMAMapView!) {
        self.mapView = mapView
    }
    
    
    /** Find closest entrance to room*/
    public func bestEntrance(entrances: [MapRoom], room: String) -> MapRoom? {
        
        let mapRoutes = IndoorMaps.getMapRoutes()
        let dijkstra = Dijkstra(routes: mapRoutes)
        
        if let destination: NMAGeoCoordinates = IndoorMaps.findCoord(name: room)?.getCoords() {
            
            // Save first element
            var bestEntrance: MapRoom = entrances[0]
            var bestCost: Float = dijkstra.getTotalCost(from: entrances[0].getCoords(), to: destination)
            
            // Loop through remaining entrances
            for i in 1..<entrances.count {
                let newCost: Float = dijkstra.getTotalCost(from: entrances[i].getCoords(), to: destination)
                
                // Update best entrance
                if (newCost < bestCost) {
                    bestCost = newCost
                    bestEntrance = entrances[i]
                }
            }
            
            return bestEntrance
        }
        else {
            return nil
            
        }
    }
    
    
    /** Plot a path from building entrance to room */
    public func indoorPath(entrance: NMAGeoCoordinates, room: String) {
        let mapRoutes = IndoorMaps.getMapRoutes()
        let dijkstra = Dijkstra(routes: mapRoutes)
        
        
        let start: NMAGeoCoordinates = entrance
        if let end: NMAGeoCoordinates = IndoorMaps.findCoord(name: room)?.getCoords() {
            
            // Draw recommened route
            if let path: [MapRoute] = dijkstra.getShortestPath(from: start, to: end) {
                addPath(routes: path, routeType: "Path")
            }
            else {
                print("Unable to create a route")
            }
        }
        else { return }
    }
    
    
    /** Add indoor paths on to map */
    public func addPath(routes: [MapRoute], routeType: String) {
        
        // Clear previous routes
        clearPath()
        
        
        // Set line colour
        var colour: UIColor
        if (routeType == "Path") {
            colour = UIColor.blue
        }
        else if (routeType == "Routes") {
            colour = UIColor.yellow
        }
        else {
            colour = UIColor.red
        }
        
        
        // Draw line for each route
        for i in 0..<routes.count {
            let points: [NMAGeoCoordinates] = routes[i].getCoords() as! [NMAGeoCoordinates]
            
            // Create a NMAGeoBoundingBox with center gec coordinates, width and hegiht in degrees.
            geoBoxes.append(NMAGeoBoundingBox(coordinates: points))
            
            geoLines = geoBoxes.map{ _ in NMAMapPolyline(vertices: points) }
            
            
            // Set line width
            geoLines[i]?.lineWidth = 12;
            
            // Set line colour
            geoLines[i]?.lineColor = colour
            
            // Add NMAMapPolyline to map view
            _ = geoLines[i].map { mapView?.add(mapObject: $0) }
        }
    }
    
    
    /** Remove all indoor paths from map */
    public func clearPath() {
        
        // Clear possible route choice objects from map
        for geoLine in geoLines {
            _ = geoLine.map{ mapView.remove(mapObject: $0) }
        }
        
        geoBoxes = []
        geoLines = []
    }
}


   

/* TESTING CLASS */
class IndoorRouteTesting {
    
    init() { }
    
    
    /** Find closest entrance to room*/
    public func bestEntranceUsingNewDijkstra(entrances: [MapRoom], room: String) -> MapRoom? {
        
        let mapRoutes = IndoorMaps.getMapRoutes()
        let dijkstra = Dijkstra(routes: mapRoutes, standardDijkstra: false)
        
        if let destination: NMAGeoCoordinates = IndoorMaps.findCoord(name: room)?.getCoords() {
            
            // Save first element
            var bestEntrance: MapRoom = entrances[0]
            var bestCost: Float = dijkstra.getTotalCost(from: entrances[0].getCoords(), to: destination)
            
            // Loop through remaining entrances
            for i in 1..<entrances.count {
                let newCost: Float = dijkstra.getTotalCost(from: entrances[i].getCoords(), to: destination)
                
                // Update best entrance
                if (newCost < bestCost) {
                    bestCost = newCost
                    bestEntrance = entrances[i]
                }
            }
            
            return bestEntrance
        }
        else {
            return nil
            
        }
    }
    
    
    /** Testing function using standard Dijkstra's algorith to find closest entrance to room*/
    public func bestEntranceUsingStandardDijkstra(entrances: [MapRoom], room: String) -> MapRoom? {
        
        let mapRoutes = IndoorMaps.getMapRoutes()
        let dijkstra = Dijkstra(routes: mapRoutes, standardDijkstra: true)
        
        if let destination: NMAGeoCoordinates = IndoorMaps.findCoord(name: room)?.getCoords() {
            
            // Save first element
            var bestEntrance: MapRoom = entrances[0]
            var bestCost: Float = dijkstra.getTotalCost(from: entrances[0].getCoords(), to: destination)
            
            // Loop through remaining entrances
            for i in 1..<entrances.count {
                let newCost: Float = dijkstra.getTotalCost(from: entrances[i].getCoords(), to: destination)
                
                // Update best entrance
                if (newCost < bestCost) {
                    bestCost = newCost
                    bestEntrance = entrances[i]
                }
            }
            
            return bestEntrance
        }
        else {
            return nil
            
        }
    }
    
    
    /** Testing function using new Dijkstra's algorith */
    public func indoorPathUsingNewDijkstra(entrance: NMAGeoCoordinates, room: String) {
        print("NEW DIJKSTRA")
        print("============")
        
        let mapRoutes = IndoorMaps.getMapRoutes()
        let dijkstra = Dijkstra(routes: mapRoutes, standardDijkstra: false)
        
        
        let start: NMAGeoCoordinates = entrance
        if let end: NMAGeoCoordinates = IndoorMaps.findCoord(name: room)?.getCoords() {
            
            // Draw recommened route
            if let path: [MapRoute] = dijkstra.getShortestPath(from: start, to: end) {
                
                print("Total Cost: \(dijkstra.getTotalCost(from: start, to: end))\n")
            }
            else {
                print("Unable to create a route")
            }
        }
        else { return }
    }
    
    
    /** Testing function using standard Dijkstra's algorithm */
    public func indoorPathUsingStandardDijkstra(entrance: NMAGeoCoordinates, room: String) {
        print("STANDARD DIJKSTRA")
        print("=================")
        
        let mapRoutes = IndoorMaps.getMapRoutes()
        let dijkstra = Dijkstra(routes: mapRoutes, standardDijkstra: true)
        
        
        let start: NMAGeoCoordinates = entrance
        if let end: NMAGeoCoordinates = IndoorMaps.findCoord(name: room)?.getCoords() {
            
            // Draw recommened route
            if let path: [MapRoute] = dijkstra.getShortestPath(from: start, to: end) {
                
                print("Total Cost: \(dijkstra.getTotalCost(from: start, to: end))\n")
            }
            else {
                print("Unable to create a route")
            }
        }
        else { return }
    }
    
}

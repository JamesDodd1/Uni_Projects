
import UIKit
import NMAKit
import CoreFoundation

/*
 * **************************************************
 * CODE ADAPTED FROM
 * Title: routing-ios-swift
 * Author: HERE Technologies
 * Date: 2020
 * Available at: https://github.com/heremaps/here-ios-sdk-examples/tree/master/routing-ios-swift
 * **************************************************
 */
class OutdoorRoute {
    @IBOutlet weak var mapView: NMAMapView!
    
    var coreRouter: NMACoreRouter!
    var mapRouts = [NMAMapRoute]()
    var progress: Progress? = nil
    
    
    init (mapView: NMAMapView!) {
        self.mapView = mapView
 
        coreRouter = NMACoreRouter()
    }
    
    
    /** Add outdoor route onto map */
    public func addRoutes(from: NMAGeoCoordinates, to: NMAGeoCoordinates) {
        
        clearRoute()
        
        // Create an array of points
        let points = NSMutableArray.init(objects: from, to)
        
        
        // Create the NMARoutingMode and set its transport mode & routing type
        let routingMode = NMARoutingMode.init(
            routingType: NMARoutingType.fastest,
            transportMode: NMATransportMode.pedestrian,
            routingOptions: NMARoutingOption(rawValue: 0)
        )
        
        
        // Calculate route
        coreRouter.calculateRoute(withPoints: points as! [NMAGeoCoordinates], routingMode: routingMode, { (routeResult, error) in
            if (error != NMARoutingError.none) {
                NSLog("Error in callback: \(error)")
                return
            }
            
            guard let route = routeResult?.routes?.first else {
                print("Empty Route result")
                return
            }
            
            guard let box = route.boundingBox, let mapRoute = NMAMapRoute.init(route) else {
                print("Can't init Map Route")
                return
            }
            
            if (self.mapRouts.count != 0) {
                for route in self.mapRouts {
                    self.mapView.remove(mapObject: route)
                }
                self.mapRouts.removeAll()
            }
            
            self.mapRouts.append(mapRoute)
            self.mapView.add(mapObject: mapRoute)
        })
    }
    
    
    /** Remove all outdoor routes */
    public func clearRoute() {
        
        // Remove all routes
        for route in mapRouts {
            mapView.remove(mapObject: route)
        }
    }
}

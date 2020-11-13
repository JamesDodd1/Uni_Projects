
import UIKit
import NMAKit
import Foundation
import CoreLocation


class User {
    private var coreRouter: NMACoreRouter!
    private var location: NMAGeoCoordinates?
    private var deviceID: Int
    
    
    init(deviceID: Int) {
        self.deviceID = deviceID
        
        // Connect to server
        Server.connectUser(user: self)
    }
    
    
    public func getLocation() -> NMAGeoCoordinates? { return self.location }
    public func setLocation(coords: NMAGeoCoordinates) { self.location = coords }
    
    public func getDeviceID() -> Int { return self.deviceID }
    
    
    
    
    /* FOR SIMULATON */
    
    private var mapCircle : NMAMapCircle?
    
    
    /** Display user on map */
    public func display(mapView: NMAMapView!) {
        
        remove(mapView: mapView)
        
        mapCircle = NMAMapCircle(location, radius: 2)
        mapCircle?.fillColor = UIColor.red
        mapCircle?.lineWidth = 2;
        mapCircle?.lineColor = UIColor.red
        
        // Add circle to map
        _ = mapCircle.map{ mapView.add(mapObject: $0) }
    }
    
    
    /** Remove user from map */
    private func remove(mapView: NMAMapView!) {
        
        // Clear location objects from map
        _ = mapCircle.map{ mapView.remove(mapObject: $0) }
        mapCircle = nil
    }
}



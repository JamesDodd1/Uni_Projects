//
//  MapPoints.swift
//  MapObjectsApp
//
//  Created by James Dodd on 18/04/2020.
//  Copyright © 2020 HERE Burnaby. All rights reserved.
//

import UIKit
import NMAKit
import Foundation

class IndoorMaps {
    var mapCoords: [MapCoord] = []
    var mapRoutes: [MapRoute] = []
    
    init() {
        setMapCoords()
        setMapRoutes()
    }

    public func setMapCoords() {
        mapCoords.append(MapCoord(name: "Point 0", coord: NMAGeoCoordinates(latitude: 51.463, longitude: 0.004))) 
        mapCoords.append(MapCoord(name: "Point 1", coord: NMAGeoCoordinates(latitude: 51.473, longitude: 0.004)))
        mapCoords.append(MapCoord(name: "Point 2", coord: NMAGeoCoordinates(latitude: 51.483, longitude: 0.004)))
        mapCoords.append(MapCoord(name: "Point 3", coord: NMAGeoCoordinates(latitude: 51.493, longitude: 0.004)))
        mapCoords.append(MapCoord(name: "Point 4", coord: NMAGeoCoordinates(latitude: 51.473, longitude: -0.006)))
        mapCoords.append(MapCoord(name: "Point 5", coord: NMAGeoCoordinates(latitude: 51.483, longitude: -0.006)))
        mapCoords.append(MapCoord(name: "Point 6", coord: NMAGeoCoordinates(latitude: 51.493, longitude: -0.006)))
        mapCoords.append(MapCoord(name: "Point 7", coord: NMAGeoCoordinates(latitude: 51.473, longitude: -0.016)))
        mapCoords.append(MapCoord(name: "Point 8", coord: NMAGeoCoordinates(latitude: 51.483, longitude: -0.016)))
        mapCoords.append(MapCoord(name: "Point 9", coord: NMAGeoCoordinates(latitude: 51.493, longitude: -0.016)))
        mapCoords.append(MapCoord(name: "Point 10", coord: NMAGeoCoordinates(latitude: 51.503, longitude: -0.016)))
    }
    
    
    public func setMapRoutes() {
        // First Row
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.463, longitude: 0.004),
                                   coord2: NMAGeoCoordinates(latitude: 51.473, longitude: 0.004),
                                   weight: 2))
        
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.473, longitude: 0.004),
                                   coord2: NMAGeoCoordinates(latitude: 51.483, longitude: 0.004),
                                   weight: 9))
        
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.483, longitude: 0.004),
                                   coord2: NMAGeoCoordinates(latitude: 51.493, longitude: 0.004),
                                   weight: 2))
        
        // Second Row
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.473, longitude: -0.006),
                                   coord2: NMAGeoCoordinates(latitude: 51.483, longitude: -0.006),
                                   weight: 9))
        
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.483, longitude: -0.006),
                                   coord2: NMAGeoCoordinates(latitude: 51.493, longitude: -0.006),
                                   weight: 3))
        
        // Third Row
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.473, longitude: -0.016),
                                   coord2: NMAGeoCoordinates(latitude: 51.483, longitude: -0.016),
                                   weight: 1))
        
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.483, longitude: -0.016),
                                   coord2: NMAGeoCoordinates(latitude: 51.493, longitude: -0.016),
                                   weight: 4))
        
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.493, longitude: -0.016),
                                   coord2: NMAGeoCoordinates(latitude: 51.503, longitude: -0.016),
                                   weight: 4))
        
        // First Column
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.473, longitude: 0.004),
                                   coord2: NMAGeoCoordinates(latitude: 51.473, longitude: -0.006),
                                   weight: 3))
        
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.473, longitude: -0.006),
                                   coord2: NMAGeoCoordinates(latitude: 51.473, longitude: -0.016),
                                   weight: 1))
        
        // Second Column
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.483, longitude: 0.004),
                                   coord2: NMAGeoCoordinates(latitude: 51.483, longitude: -0.006),
                                   weight: 3))
        
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.483, longitude: -0.006),
                                   coord2: NMAGeoCoordinates(latitude: 51.483, longitude: -0.016),
                                   weight: 1))
        
        // Third Column
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.493, longitude: 0.004),
                                   coord2: NMAGeoCoordinates(latitude: 51.493, longitude: -0.006),
                                   weight: 2))
        
        mapRoutes.append(MapRoute(coord1: NMAGeoCoordinates(latitude: 51.493, longitude: -0.006),
                                   coord2: NMAGeoCoordinates(latitude: 51.493, longitude: -0.016),
                                   weight: 2))
    }
    
    
    public func getMapCoords() -> [MapCoord] { return self.mapCoords }
    public func getMapRoutes() -> [MapRoute] { return self.mapRoutes }
}


class MapCoord {
    private var name: String
    private var coords: NMAGeoCoordinates
    
    init(name: String, coord: NMAGeoCoordinates) {
        self.name = name
        self.coords = coord
    }
    
    public func getName() -> String { return self.name }
    public func getCoords() -> NMAGeoCoordinates { return self.coords }
}


class MapRoute {
    private var coords: NSMutableArray
    private var weight: Float
    
    init(coord1: NMAGeoCoordinates, coord2: NMAGeoCoordinates, weight: Float) {
        self.coords = NSMutableArray.init(objects: coord1, coord2)
        self.weight = weight
    }
    
    public func getCoords() -> NSMutableArray { return self.coords }
    public func getWeight() -> Float { return self.weight }
}

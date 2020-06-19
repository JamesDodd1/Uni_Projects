
import UIKit
import NMAKit
import Foundation

class IndoorMaps {
    private static var mapCoords: [MapRoom] = []
    private static var mapRoutes: [MapRoute] = []
    
    
    private init() { }
    
    
    /** Setup indoor map rooms and routes */
    public static func setupMaps(files: [String]) {
        let gpx = GPX()
        
        // Loop through all files
        for file in files {
            
            // Get all rooms
            for room in gpx.getRooms(fileName: file) {
                
                let name: String = room[0]
                let lat: Double = (room[1] as NSString).doubleValue
                let lon: Double = (room[2] as NSString).doubleValue
                
                mapCoords.append(MapRoom(building: file, name: name, coord: NMAGeoCoordinates(latitude: lat, longitude: lon)))
            }
            
            
            // Get all routes
            for routes in gpx.getRoutes(fileName: file) {
                
                let lat1: Double = (routes[0][0] as NSString).doubleValue
                let lon1: Double = (routes[0][1] as NSString).doubleValue
                let lat2: Double = (routes[1][0] as NSString).doubleValue
                let lon2: Double = (routes[1][1] as NSString).doubleValue
                let weight: Double = calcWeight(x1: lon1, y1: lat1, x2: lon2, y2: lat2)
                
                mapRoutes.append(MapRoute(building: file, coord1: NMAGeoCoordinates(latitude: lat1, longitude: lon1),
                                          coord2: NMAGeoCoordinates(latitude: lat2, longitude: lon2),
                                          weight: Float(weight)))
            }
        }
    }
    
    
    /** Find all indoor map building entrances */
    public static func findBuildingEntrances(roomName: String) -> [MapRoom] {
        var entrances: [MapRoom] = []
        var building: String = ""
        
        // Find building
        for mapCoord in mapCoords {
            if (mapCoord.getName() == roomName) {
                building = mapCoord.getBuilding()
            }
        }
        
        // Find all entrances to building
        for mapCoord in mapCoords {
            if (mapCoord.getName() == "Entrance" && building == mapCoord.getBuilding()) {
                entrances.append(mapCoord)
            }
        }
        
        return entrances
    }
    
    
    /** Find indoor map room form name */
    public static func findCoord(name: String) -> MapRoom? {
        for mapCoord in mapCoords {
            if (mapCoord.getName() == name) {
                return mapCoord
            }
        }
        
        return nil
    }
    
    
    /** FInd indoor map room from coordinates */
    public static func findCoord(position: NMAGeoCoordinates) -> MapRoom? {
        for mapCoord in mapCoords {
            let coord = mapCoord.getCoords()
            if (coord.latitude == position.latitude && coord.longitude == position.longitude) {
                return mapCoord
            }
        }
        
        return nil
    }
    
    
    /** Calculates the weight of a routes */
    private static func calcWeight(x1: Double, y1: Double, x2: Double, y2: Double) -> Double {
        
        var difX: Double = x2 - x1
        var difY: Double = y2 - y1
        
        // Vertical line
        if (difX == 0) {
            // If negative
            if (difY < 0) {
                difY *= -1
            }
            
            // If number isn't too small to register
            if (!difY.isNaN) {
                return difY
            }
            return 0
        }
        // Horizontal line
        else if (difY == 0) {
            // If negative
            if (difX < 0) {
                difX *= -1
            }
            
            // If number isn't too small to register
            if (!difX.isNaN) {
                return difX
            }
            return 0
        }
        // Diagonal line
        else {
            let lengthSqrd = (difY * difY) + (difX * difX)
            var length = lengthSqrd.squareRoot()
            
            // If negative
            if (length < 0) {
                length *= -1
            }
            
            // If number isn't too small to register
            if (!length.isNaN) {
                return length
            }
            return 0
        }
    }
    
    
    /** Finds route at a coordinate */
    public static func findRoute(position: NMAGeoCoordinates) -> MapRoute? {
        
        // Find which route position is on
        for route in IndoorMaps.mapRoutes {
            let coord1 = route.getCoords()[0] as! NMAGeoCoordinates
            let coord2 = route.getCoords()[1] as! NMAGeoCoordinates
            
            
            // If position matches either node
            if (position.longitude == coord1.longitude && position.latitude == coord1.latitude ||
                position.longitude == coord2.longitude && position.latitude == coord2.latitude) {
                return route
            }
            
            
            
            let latDif = coord1.latitude - coord2.latitude
            let longDif = coord1.longitude - coord2.longitude
            
            
            // Vertical line
            if (latDif == 0) { // Vertical line
                
                let longInRange = inRange(pos: position.longitude, dif: longDif,
                                          lat1: coord1.longitude, lat2: coord2.longitude)
                
                // If coordinates out of range
                if (!longInRange) {
                    continue
                }
                
                return route
            }
            // Horizontal line
            else if (longDif == 0) { // Horizontal line
                
                let latInRange = inRange(pos: position.latitude, dif: latDif,
                                         lat1: coord1.latitude, lat2: coord2.latitude)

                // If coordinates out of range
                if (!latInRange) {
                    continue
                }
                
                return route
            }
            else {
                let latInRange = inRange(pos: position.latitude, dif: latDif,
                                         lat1: coord1.latitude, lat2: coord2.latitude)
                let longInRange = inRange(pos: position.longitude, dif: longDif,
                                          lat1: coord1.longitude, lat2: coord2.longitude)
                
                // If coordinates out of range
                if (!latInRange || !longInRange) {
                    continue
                }
                
                return route
            }
        }
        
        return nil
    }
    
    
    private static func inRange(pos: Double, dif: Double, lat1: Double, lat2: Double) -> Bool {
        var large: Double = 0
        var small: Double = 0
        
        // Setting large and small values
        if (dif > 0) {
            large = lat1
            small = lat2
        }
        else {
            large = lat2
            small = lat1
        }
        
        
        if (pos < small || pos > large) {
            return false
        }
        
        return true
    }
    
    
    public static func getMapCoords() -> [MapRoom] { return self.mapCoords }
    public static func getMapRoutes() -> [MapRoute] { return self.mapRoutes }
}


/** Indoor map building */
class MapBuilding {
    private var name: String
    
    init(name: String) {
        self.name = name
    }
    
    public func getBuilding() -> String { return self.name }
}


/** Indoor map room */
class MapRoom: MapBuilding {
    private var room: String
    private var coords: NMAGeoCoordinates
    
    init(building: String, name: String, coord: NMAGeoCoordinates) {
        self.room = name
        self.coords = coord
        
        super.init(name: building)
    }
    
    public func getName() -> String { return self.room }
    public func getCoords() -> NMAGeoCoordinates { return self.coords }
}


/** Indoor map route */
class MapRoute: MapBuilding {
    private var coords: NSMutableArray
    private var weight: Float
    
    init(building: String, coord1: NMAGeoCoordinates, coord2: NMAGeoCoordinates, weight: Float) {
        self.coords = NSMutableArray.init(objects: coord1, coord2)
        self.weight = weight
        
        super.init(name: building)
    }
    
    public func getCoords() -> NSMutableArray { return self.coords }
    public func getWeight() -> Float { return self.weight }
}

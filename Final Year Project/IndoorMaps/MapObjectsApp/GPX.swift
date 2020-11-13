
import Foundation

class GPX {

    init() { }
    
    
    /** Read a GPX file  */
    private func readGPX(fileName: String) -> [String]? {
        
        if let path = Bundle.main.path(forResource: fileName, ofType: "gpx"){
            do {
                let data = try String(contentsOfFile: path, encoding: .utf8)
                let lines = data.components(separatedBy: .newlines)
                
                return lines
            }
            catch {
                print(error)
            }
        }
        
        return nil
    }
    
    
    /** Get all rooms from a GPX file */
    public func getRooms(fileName: String) -> [[String]] {
        
        var rooms: [[String]] = []
        
        do {
            var skip: Bool = false
            var name: String = ""
            
            // If file contains text
            if let fileText = readGPX(fileName: fileName) {
                
                var coords: Bool = false
                for i in 0..<fileText.count {
                    
                    if (skip) {
                        skip = false
                        continue
                    }
                    
                    let line = fileText[i].trimmingCharacters(in: .whitespacesAndNewlines)
                    
                    
                    // Name line
                    if (line.count > 5 && line.prefix(6) == "<name>") {
                        name = getName(text: line)
                    }
                    
                    
                    // Beginning or end of coordinates
                    if (line == "<trkseg>") {
                        coords = true
                        continue
                    }
                    else if (line == "</trkseg>") {
                        coords = false
                        continue
                    }
                    
                    
                    // If coordinates on these lines
                    if (coords) {
                        if (line.prefix(6) == "<trkpt") {
                            let point = getCoords(text: line)
                            
                            let nextLine = fileText[i + 1].trimmingCharacters(in: .whitespacesAndNewlines)
                            
                            
                            // No more coordinates
                            if (nextLine.prefix(6) != "<trkpt") {
                                rooms.append([name, point[0], point[1]])
                            }
                            else {
                                skip = true
                            }
                        }
                    }
                }
            }
        }
        catch {
            print(error)
        }
        
        
        return rooms
    }
    
    
    /** Get all routes from a GPX File */
    public func getRoutes(fileName: String) -> [[[String]]] {
        
        var routes: [[[String]]] = []
        
        do {
            var skip: Bool = false
            
            // If file contains text
            if let fileText = readGPX(fileName: fileName) {
                
                var coords: Bool = false
                for i in 0..<fileText.count {
                    
                    if (skip) {
                        skip = false
                        continue
                    }
                    
                    let line = fileText[i].trimmingCharacters(in: .whitespacesAndNewlines)
                    
                    
                    // Beginning or end of coordinates
                    if (line == "<trkseg>") {
                        coords = true
                        continue
                    }
                    else if (line == "</trkseg>") {
                        coords = false
                        continue
                    }
                    
                    
                    // If coordinates on these lines
                    if (coords) {
                        if (line.prefix(6) == "<trkpt") {
                            let pointA = getCoords(text: line)
                            
                            let nextLine = fileText[i + 1].trimmingCharacters(in: .whitespacesAndNewlines)
                            
                            if (nextLine.prefix(6) == "<trkpt") {
                                routes.append([pointA, getCoords(text: nextLine)])
                                
                                skip = true
                            }
                        }
                    }
                }
            }
        }
        catch {
            print(error)
        }
        
        
        return routes
    }
    
    
    /** Get the coordinates from a line of text */
    private func getCoords(text: String) -> [String] {
        
        let chars = Array(text)
        var num: String = ""
        var lat: String = ""
        var lon: String = ""
        var lonVal: Bool = false
        
        for i in 12..<(chars.count - 9) {
            
            // Get latitude value
            if (lat == "") {
                if (chars[i] != "\"") {
                    num.append(chars[i])
                }
                else {
                    lat = num
                    num = ""
                    
                    continue
                }
            }
            // Get longitude value
            else if (lon == "") {
                // Arrived at longitude value
                if (chars[i] == "\"") {
                    
                    // Only save values with quotes
                    if (!lonVal){
                        lonVal = true
                    }
                    else {
                        lon = num
                        num = ""
                        
                        lonVal = false
                    }
                    
                    continue
                }
                else if (lonVal) {
                    num.append(chars[i])
                }
            }
        }
        
        return [lat, lon]
    }
    
    
    /** Get the name from a line of text */
    private func getName(text: String) -> String {
        
        let chars = Array(text)
        var name: String = ""
        
        for i in 6..<(chars.count - 7) {
            name.append(chars[i])
        }
        
        return name
    }
}

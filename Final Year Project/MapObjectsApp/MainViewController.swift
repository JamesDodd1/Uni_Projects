
import UIKit
import NMAKit
import MapKit

class MainViewController: UIViewController, CLLocationManagerDelegate {
    @IBOutlet weak private var mapView: NMAMapView!
    @IBOutlet weak var roomName: UITextField!
    
    private var user: User?
    private var outdoor: OutdoorRoute!
    private var indoor: IndoorRoute!
    
    
    /*
     * **************************************************
     * CODE OBTAINED FROM
     * Title: In Swift, how can I store the user's location inside a variable when I press a button?
     * Author: Azat
     * Date: 2015
     * Available at:  https://stackoverflow.com/questions/30144254/in-swift-how-can-i-store-the-users-location-inside-a-variable-when-i-press-a-b
     * **************************************************
     */
    var location: CLLocation! //to store location
    lazy var locationManager: CLLocationManager = {
        let _locationManager = CLLocationManager()
        _locationManager.requestWhenInUseAuthorization()
        
        // adjsut _locationManager
        return _locationManager
    }()
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        findLocation()
        user = User(deviceID: 0) // Device ID would be actual ID if used
        
        
        // Setup indoor maps
        IndoorMaps.setupMaps(files: ["King William", "Queen Mary"])
        
        self.outdoor = OutdoorRoute(mapView: mapView)
        self.indoor = IndoorRoute(mapView: mapView)
        
        displayIndoorPaths()
        
        
        // Create simulated random people
        let people = SimulatedPeople(map: mapView)
        people.createAtRandomLocations(amount: 100)
        //people.createAtLocation(amount: 1000, location: NMAGeoCoordinates(latitude: 51.482673, longitude: -0.004170)) // Main entrance of Queen Mary
        
        
        /* Testing */
        //let testing = Testing()
        //testing.Test1()
        //testing.Test2()
        //testing.Test3()
    }
    
    
    /** Draw all available indoor routes */
    private func displayIndoorPaths() {
        let mapRoutes = IndoorMaps.getMapRoutes()
        let indoorPaths = IndoorRoute(mapView: mapView)
        
        // Draw all possible routes
        indoorPaths.addPath(routes: mapRoutes, routeType: "Routes")
    }
    

    /** Go button draws path to chosen location */
    @IBAction func goButton(_ sender: UIButton) { //event handler
        let position = NMAGeoCoordinates(latitude: (locationManager.location?.coordinate.latitude)!,
                                         longitude: (locationManager.location?.coordinate.longitude)!) // get current location
        let room = roomName.text!
        
        
        let entrances: [MapRoom] = IndoorMaps.findBuildingEntrances(roomName: room)
        if let bestEntrance: MapRoom = indoor.bestEntrance(entrances: entrances, room: room) {
            
            // Draw outdoor path
            outdoor?.clearRoute()
            outdoor?.addRoutes(from: position, to: bestEntrance.getCoords())
            
            
            // Draw available indoor routes
            displayIndoorPaths()
            
            
            // Draw indoor path
            indoor.clearPath()
            indoor.indoorPath(entrance: bestEntrance.getCoords(), room: room)
        }
    }
    
    
    /** Clear button resets the layout */
    @IBAction func clear(_ sender: UIButton) {
        displayIndoorPaths()
        indoor.clearPath()
        outdoor.clearRoute()
    }
    
    
    /*
     * **************************************************
     * CODE OBTAINED FROM
     * Title: Show Current Location and Update Location in MKMapView in Swift
     * Author: PMIW
     * Date: 2014
     * Available at: https://stackoverflow.com/questions/25449469/show-current-location-and-update-location-in-mkmapview-in-swift
     * **************************************************
     */
    func findLocation() {
        if (CLLocationManager.locationServicesEnabled())
        {
            locationManager = CLLocationManager()
            locationManager.delegate = self
            locationManager.desiredAccuracy = kCLLocationAccuracyBest
            locationManager.requestAlwaysAuthorization()
            locationManager.startUpdatingLocation()
        }
    }
    func locationManager(_ manager: CLLocationManager, didUpdateLocations locations: [CLLocation]) {
        
        // Set map to show device's position
        if let location = locations.last{
            let position: NMAGeoCoordinates = NMAGeoCoordinates(latitude: location.coordinate.latitude, longitude: location.coordinate.longitude)
            self.mapView.set(geoCenter: position, animation: NMAMapAnimation.none)
            
            // Turn on position indicator
            mapView.positionIndicator.isVisible = true
            //mapView.positionIndicator.isAccuracyIndicatorVisible = true
            
            user?.setLocation(coords: position)
        }
    }
}


class SimulatedPeople {
    
    @IBOutlet weak private var mapView: NMAMapView!
    private var mapSet: Bool = false
    
    init() { }
    init(map: NMAMapView) {
        self.mapView = map
        self.mapSet = true
    }
    
    
    public func createAtRandomLocations(amount: Int) {
        
        let indoorRoutes = IndoorMaps.getMapRoutes()
        
        // Create people
        for i in 0...amount {
            let user = User(deviceID: i)
            user.setLocation(coords: randPos(routes: indoorRoutes))
            
            if (mapSet) {
                user.display(mapView: mapView)
            }
        }
    }
    
    
    public func createAtLocation(amount: Int, location: NMAGeoCoordinates) {
        
        // Create people
        for i in 0...amount {
            let user = User(deviceID: i)
            user.setLocation(coords: location)
            
            if (mapSet) {
                user.display(mapView: mapView)
            }
        }
    }
    
    
    /** Select a random position on a random route */
    private func randPos(routes: [MapRoute]) -> NMAGeoCoordinates {
        
        // Get end coordinates of a random route
        let num = Int.random(in: 0..<routes.count)
        let coord1 = routes[num].getCoords()[0] as! NMAGeoCoordinates
        let coord2 = routes[num].getCoords()[1] as! NMAGeoCoordinates
        
        // Create percentage
        let rand = Int.random(in: 0..<100)
        let percent: Double = Double(rand) / 100
        
        // Calulated difference
        let latDif = coord1.latitude - coord2.latitude
        let longDif = coord1.longitude - coord2.longitude
        
        // Select position on route
        let randLat = coord1.latitude - (latDif * percent)
        let randLong = coord1.longitude - (longDif * percent)
        
        return NMAGeoCoordinates(latitude: randLat, longitude: randLong)
    }
}


class Testing {
    private var indoor: IndoorRouteTesting!
    private let room: String = "W018"
    
    
    init() {
        // Setup indoor maps
        IndoorMaps.setupMaps(files: ["King William", "Queen Mary"])
        
        self.indoor = IndoorRouteTesting()
    }
    
    
    // Testing with no simulated people
    public func Test1() {
        print("TEST 1 (No simulated people) - Destination \(room) \n")
        
        let entrances: [MapRoom] = IndoorMaps.findBuildingEntrances(roomName: room)
        
        // Indoor Map's Dijkstra's algorithm
        if let bestEntrance: MapRoom = indoor.bestEntranceUsingNewDijkstra(entrances: entrances, room: room) {
            indoor.indoorPathUsingNewDijkstra(entrance: bestEntrance.getCoords(), room: room)
        }
        
        // Standard Dijkstra's algorithm
        if let bestEntrance: MapRoom = indoor.bestEntranceUsingStandardDijkstra(entrances: entrances, room: room) {
            indoor.indoorPathUsingStandardDijkstra(entrance: bestEntrance.getCoords(), room: room)
        }
    }
    
    
    // Testing with 1000 simulated people at random location
    public func Test2() {
        print("TEST 2 (1000 simulated people at random locations) - Destination \(room) \n")
        
        let people = SimulatedPeople()
        people.createAtRandomLocations(amount: 1000)
        
        let entrances: [MapRoom] = IndoorMaps.findBuildingEntrances(roomName: room)
        
        // Indoor Map's Dijkstra's algorithm
        if let bestEntrance: MapRoom = indoor.bestEntranceUsingNewDijkstra(entrances: entrances, room: room) {
            indoor.indoorPathUsingNewDijkstra(entrance: bestEntrance.getCoords(), room: room)
        }
        
        // Standard Dijkstra's algorithm
        if let bestEntrance: MapRoom = indoor.bestEntranceUsingStandardDijkstra(entrances: entrances, room: room) {
            indoor.indoorPathUsingStandardDijkstra(entrance: bestEntrance.getCoords(), room: room)
        }
    }
    
    
    // Testing with 1000 simulated people at one location
    public func Test3() {
        print("TEST 3 (1000 simulated people within Queen Mary main entrance) - Destination \(room) \n")
        
        let queenMaryEntrance: NMAGeoCoordinates = NMAGeoCoordinates(latitude: 51.482673, longitude: -0.004170)
        let people = SimulatedPeople()
        people.createAtLocation(amount: 1000, location: queenMaryEntrance)
        
        let entrances: [MapRoom] = IndoorMaps.findBuildingEntrances(roomName: room)
        
        // Indoor Map's Dijkstra's algorithm
        if let bestEntrance: MapRoom = indoor.bestEntranceUsingNewDijkstra(entrances: entrances, room: room) {
            indoor.indoorPathUsingNewDijkstra(entrance: bestEntrance.getCoords(), room: room)
        }
        
        // Standard Dijkstra's algorithm
        if let bestEntrance: MapRoom = indoor.bestEntranceUsingStandardDijkstra(entrances: entrances, room: room) {
            indoor.indoorPathUsingStandardDijkstra(entrance: bestEntrance.getCoords(), room: room)
        }
    }
}

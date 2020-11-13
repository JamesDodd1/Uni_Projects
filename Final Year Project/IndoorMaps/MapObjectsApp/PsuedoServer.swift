
import Foundation

class Server {
    private static var users: [User] = []
    
    init() { }
    
    public static func connectUser(user: User) {
        users.append(user)
    }
    
    public static func getUsers() -> [User]? { return users }
}

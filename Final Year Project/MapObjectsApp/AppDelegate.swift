
import UIKit
import NMAKit

// To obtain the application credentials, please register at https://developer.here.com/develop/mobile-sdks
let credentials = (
    appId: "yLWUzjsEvpKQe45rs7ps",
    appCode: "xa_ZAt7lNiSnrGv1WzfHJw",
    licenseKey: "jwqzSlEag3HqwWu5MfIshMhflTmYUbxhBy/3O7jFWwyS7mzzipuGvozUUWiGSwI3SYtvN6b279nhLsFtcr1W+ZMZsAJBExlInJ4m+ufnBssRugov0FeHuYSk1vUIR2bdAz9Qg25/GMeqj4OGyFTx1qNOp/5RWfWlFfdGeD5xYe43za7bJwTcnRVBUI9Im0dz3kXj9nM7k5yuAdECgQ11ME5jM3FiODps9WQsLp3Rlp5KWm1fpVyAjTbe6YQhXBgh01nPbGJZRcHAevLsV6+X9ew0Klamzhx6hD3kBPwAwkBtsRGRuxT/OYGJwTbwRblet9wJmWBvNIVHFlIhohw1aeEQZ4rOmspFwXWEAwHmVkmewtMd9SVw6tu2KI3YfBZNUNAA0ZWuXYfReHCGPoRHJnha0SkJQGYAHLGkXLbUCmTJojLmFNHcP7oh7IZIUD3b6aQ/FvoWvXS4i3S2lD0j08JQw6ytNKJ+BB3qTM9tnWIU1yQ8P4fdX3depr0d/0682N425VVIHkvpCGYqkUYvEnNX+8FXOFmGT65mW78SvPlpCuqUZmiGHs+AuLYaKgckXI0CfBhp02114G9mb3cPoEohPGfYe6MS8eVFRVLYJ/TN3bTATuXuMp5WbFUzDsqqn7wMdfJ/xMIiaZBXzJB6m0p3WEpWUpufzaAFZETys2w="
)

@UIApplicationMain
class AppDelegate: UIResponder, UIApplicationDelegate {

    var window: UIWindow?

    func application(_ application: UIApplication, didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey: Any]?) -> Bool {
        NMAApplicationContext.setAppId(credentials.appId, appCode: credentials.appCode, licenseKey: credentials.licenseKey)
        return true
    }
}

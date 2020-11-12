
package DigitalFactoryPattern;


public class CreateDigital {
    
    public static Digital createDigital(String dashboardType) {
        switch (dashboardType) {
            case "Fuel" :
                CreateFuelDigital fuel = new CreateFuelDigital();
                fuel.setTitle("FUEL");
                return fuel;
            case "Speed" :
                CreateSpeedDigital speed = new CreateSpeedDigital();
                speed.setTitle("SPEED");
                return speed;
            case "Temp" :
                CreateTempDigital temp = new CreateTempDigital();
                temp.setTitle("TEMPERATURE");
                return temp;
            default :
                return null;
        }
    }
}

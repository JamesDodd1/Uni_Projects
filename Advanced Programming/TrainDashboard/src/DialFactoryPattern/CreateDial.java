
package DialFactoryPattern;


public class CreateDial {
    
    public static Dial createDial(String dashboardType) {
        switch (dashboardType) {
            case "Speed" :
                CreateSpeedDial speedDial = new CreateSpeedDial();
                speedDial.setTitle("SPEED");
                return speedDial;
            case "Temp" :
                CreateTempDial tempDial = new CreateTempDial();
                tempDial.setTitle("TEMPERATURE");
                return tempDial;
            default :
                return null;
        }
    }
}

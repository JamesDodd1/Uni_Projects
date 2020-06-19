
package Threads;

import Dashboard.BarPanel;
import DigitalFactoryPattern.Digital;


public class FuelThread extends Thread {
    
    /* Declare variable */
    private BarPanel bar;
    private Digital digital;
    
    private int value;
    
    
    public FuelThread(BarPanel bar, Digital digital, int value) {
        this.bar = bar;
        this.digital = digital;
        this.value = value;
    }
    
    
    public void run() {
        // Declare variables
        int max = digital.getMaxValue();
        int min = digital.getMinValue();
        int currentVal = digital.getValue();
        int sleepTime = 2000 / max; // Will take 2 seconds to go from one limit to the other
        int changeVal = 0;
        
        
        // Sets value to min/max if it surpasses
        if (value > max)
            value = max;
        else if (value < min)
            value = min;
        
        
        // Sorts whether to increase or decrease dashboard objects
        if (currentVal < value) 
            changeVal = 1;
        else if (currentVal > value)
            changeVal = -1;
        
        
        // Loop until value reached
        while (currentVal != value) {
            currentVal += changeVal;

            try {
                Thread.sleep(sleepTime); // Wait for 'sleepTime' secs
            }
            catch (Exception e) {
                break;
            }
            
            // Set dashboard
            bar.setValue(currentVal);
            digital.setValue(currentVal);
        }
    }
}

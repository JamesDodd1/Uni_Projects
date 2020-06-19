
package Threads;

import DialFactoryPattern.Dial;
import DigitalFactoryPattern.Digital;


public class DialThread extends Thread {
    
    /* Declare variables */
    private Dial dial;
    private Digital digital;
    
    private int value;
    
    
    /* Speed and Temperature */
    public DialThread(Dial dial, Digital digital, int value) {
        this.dial = dial;
        this.digital = digital;
        this.value = value;
    }
    
    
    /* Do while running */
    public void run() {
        // Declare variables
        int max = (int) digital.getMaxValue();
        int min = (int) digital.getMinValue();
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
                Thread.sleep(sleepTime); // Wait 'sleepTime' secs
            }
            catch (Exception e) {
                break;
            }
            
            // Set dashboard
            dial.setValue(currentVal);
            digital.setValue(currentVal);
        }
    }
}

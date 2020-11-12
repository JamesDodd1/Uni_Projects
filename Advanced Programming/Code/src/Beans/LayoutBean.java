
package Beans;

import javax.swing.JPanel;


public class LayoutBean extends JPanel {
    
    /* Declare variables */
    protected int value, padding, maxValue, minValue; 
    
    
    public LayoutBean(int padding, int minValue, int maxValue, int value) {
        this.padding = padding;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.value = value;
    }
}

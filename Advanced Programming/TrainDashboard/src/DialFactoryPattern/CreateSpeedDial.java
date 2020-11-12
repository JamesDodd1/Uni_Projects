
package DialFactoryPattern;

import Dashboard.DialPanel;


public class CreateSpeedDial implements Dial {
    
    /* Declare variable */
    private DialPanel dial = new DialPanel(150);
    
    
    public DialPanel getDial() {
        return dial;
    }
    
    
    /* Get/Set methods */
    @Override
    public int getMaxValue() { return dial.getMaxValue(); }
    
    @Override 
    public int getMinValue() { return dial.getMinValue(); }
    
    @Override
    public int getValue() { return dial.getValue(); }
    
    @Override
    public void setValue(int value) { dial.setValue(value); }
    
    @Override
    public void setTitle(String title) { dial.setTitle(title); }
}

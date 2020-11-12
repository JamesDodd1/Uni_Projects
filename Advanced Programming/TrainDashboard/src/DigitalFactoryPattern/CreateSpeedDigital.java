
package DigitalFactoryPattern;

import Dashboard.DigitalPanel;


public class CreateSpeedDigital implements Digital {
    
    /* Declare variable */
    private DigitalPanel digital = new DigitalPanel(150);
    
    
    @Override
    public DigitalPanel getDigital() {
        return digital;
    }
    
    
    /* Get/Set methods */
    @Override
    public int getMaxValue() { return digital.getMaxValue(); }
    
    @Override 
    public int getMinValue() { return digital.getMinValue(); }
    
    @Override
    public int getValue() { return digital.getValue(); }
    
    @Override
    public void setValue(int value) { digital.setValue(value); }
    
    @Override
    public void setTitle(String title) { digital.setTitle(title); }
    
}

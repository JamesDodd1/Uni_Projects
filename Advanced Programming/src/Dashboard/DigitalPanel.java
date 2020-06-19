
package Dashboard;

import Beans.DigitalBean;
import java.awt.BorderLayout;


public class DigitalPanel extends LayoutPanel implements DashboardPanel {
    
    /* Declare variable */
    private DigitalBean digital; 
    
    
    public DigitalPanel() {
        this(100);
    }
    
    
    public DigitalPanel(int maxValue) {
        digital = new DigitalBean(maxValue);
        add(digital, BorderLayout.CENTER);
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
    public void setTitle(String label) { titleLabel.setText(label); }
    
}

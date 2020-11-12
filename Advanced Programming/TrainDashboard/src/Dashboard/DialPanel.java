
package Dashboard;

import Beans.DialBean;
import java.awt.BorderLayout;


public class DialPanel extends LayoutPanel implements DashboardPanel {
    
    /* Declare variable */
    private DialBean dial; 
    
    
    public DialPanel() {
        this(100);
    }
    
    
    public DialPanel(int maxValue) {
        dial = new DialBean(maxValue);
        add(dial, BorderLayout.CENTER);
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
    public void setTitle(String title) { titleLabel.setText(title); }
}

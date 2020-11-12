
package Dashboard;

import Beans.BarBean;
import java.awt.BorderLayout;

public class BarPanel extends LayoutPanel implements DashboardPanel {
    
    /* Declare variable */
    private BarBean bar; 
    
    
    public BarPanel() {
        bar = new BarBean();
        add(bar, BorderLayout.CENTER);
    }
    
    
    /* Get/Set methods */
    @Override 
    public int getMaxValue() { return bar.getMaxValue(); }
    
    @Override 
    public int getMinValue() { return bar.getMinValue(); }
    
    @Override 
    public int getValue() { return bar.getValue(); }
    
    @Override
    public void setValue(int value) { bar.setValue(value); }
    
    @Override
    public void setTitle(String title) { titleLabel.setText(title); }
}

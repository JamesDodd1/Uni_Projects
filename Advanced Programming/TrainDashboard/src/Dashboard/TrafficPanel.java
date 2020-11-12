
package Dashboard;

import Beans.TrafficBean;
import java.awt.BorderLayout;

public class TrafficPanel extends LayoutPanel {
    
    /* Declare variable */
    private TrafficBean traffic; // The traffic itself
    
    
    public TrafficPanel() {
        traffic = new TrafficBean();
        add(traffic, BorderLayout.CENTER);
    }
    
    
    /* Get/Set methods */
    public void setValue(boolean value) { traffic.setValue(value); }
    
    public void setLabel(String title) { titleLabel.setText(title); }
}
    


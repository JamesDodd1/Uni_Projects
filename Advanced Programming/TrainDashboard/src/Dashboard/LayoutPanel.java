
package Dashboard;

import java.awt.BorderLayout;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.border.BevelBorder;


public class LayoutPanel extends JPanel {
    
    /* Declare variable */
    protected JLabel titleLabel; // Title of object
    
    
    public LayoutPanel() {
        setLayout(new BorderLayout());
        setBorder(new BevelBorder(BevelBorder.LOWERED)); // Sets boarder style

        // Sets label position
        titleLabel = new JLabel();
        titleLabel.setHorizontalAlignment(JLabel.CENTER);
        add(titleLabel, BorderLayout.NORTH);
    }
}

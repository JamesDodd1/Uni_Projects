
package GUI;

import houseforecasting.Calc;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JTextField;


public class DataInputs {

    public DataInputs(boolean newData) {
        Container window = GUI.win.getContentPane();
        if (newData)
            GUI.win.setTitle("House Price Data Input");
        else 
            GUI.win.setTitle("House Price Comparison Data Input");
        
        window.removeAll(); // Clears window
        window.repaint();   // Remakes window
        
        isNewData = newData;
        
        
        /* ==================== LABELS ==================== */
        title.setBounds(10, 10, 300, 20);   // Sets time bounds
        window.add(title);                  // Add time label to window

        y.setBounds(10, 35, 300, 20);	// Sets y label bounds
        window.add(y);			// Add label

        x1.setBounds(10, 65, 300, 20);	// Sets x1 label bounds
        window.add(x1);			// Add label

        x2.setBounds(10, 95, 300, 20);	// Sets x2 label bounds
        window.add(x2);			// Add label

        x3.setBounds(10, 125, 300, 20);	// Sets x3 label bounds
        window.add(x3);			// Add label

        x4.setBounds(10, 155, 300, 20);	// Sets x4 label bounds
        window.add(x4);			// Add label

        x5.setBounds(10, 185, 300, 20);	// Sets x5 label bounds
        window.add(x5);			// Add label

        x6.setBounds(10, 215, 300, 20);	// Sets x6 label bounds
        window.add(x6);			// Add label

        x7.setBounds(10, 245, 300, 20);	// Sets x7 label bounds
        window.add(x7);			// Add label

        
        helpMsg.setBounds(305, 10, 300, 20);    // Sets helpMsg label bounds
        window.add(helpMsg);			// Add label
        
        
        /* ==================== TEXTBOXES ==================== */
        yInput.setBounds(300, 30, 305, 30);	// Sets yInput bounds
        window.add(yInput);                     // Add button

        x1Input.setBounds(300, 60, 305, 30);	// Sets x1Input bounds
        window.add(x1Input);                    // Add button

        x2Input.setBounds(300, 90, 305, 30);	// Sets x2Input bounds
        window.add(x2Input);                    // Add button

        x3Input.setBounds(300, 120, 305, 30);	// Sets x3Input bounds
        window.add(x3Input);                    // Add button

        x4Input.setBounds(300, 150, 305, 30);	// Sets x4Input bounds
        window.add(x4Input);                    // Add button

        x5Input.setBounds(300, 180, 305, 30);	// Sets x5Input bounds
        window.add(x5Input);                    // Add button

        x6Input.setBounds(300, 210, 305, 30);	// Sets x6Input bounds
        window.add(x6Input);                    // Add button

        x7Input.setBounds(300, 240, 305, 30);	// Sets x7Input bounds
        window.add(x7Input);                    // Add button
        
        
        /* ==================== BUTTONS ==================== */
        addVal.setBounds(300, 275, 305, 30);   // Sets addVal bounds
        window.add(addVal);                    // Add addVal button to window
        
        /* addVal button clicked */
        addVal.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                /* Textbox data separated via comma (eg '1, 2, 3') then stored into array */
                String[] yArr = yInput.getText().split(", *");
                String[] x1Arr = x1Input.getText().split(", *");
                String[] x2Arr = x2Input.getText().split(", *");
                String[] x3Arr = x3Input.getText().split(", *");
                String[] x4Arr = x4Input.getText().split(", *");
                String[] x5Arr = x5Input.getText().split(", *");
                String[] x6Arr = x6Input.getText().split(", *");
                String[] x7Arr = x7Input.getText().split(", *");
                
                String msg = Calc.arrData(yArr, x1Arr, x2Arr, x3Arr, x4Arr, x5Arr, x6Arr, x7Arr); // Calls arrData method
                
                new PopUp(msg); // Run popup
                
                if (msg.equals("Data has been added")) {
                    yInput.setText("");
                    x1Input.setText("");
                    x2Input.setText("");
                    x3Input.setText("");
                    x4Input.setText("");
                    x5Input.setText("");
                    x6Input.setText("");
                    x7Input.setText("");
                }
            }
        });
        
        
        /* RETURN BUTTON */
        menu.setBounds(5, 275, 150, 30);    // Sets menu bounds
        window.add(menu);                   // Adds menu button to window
        
        /* Menu button clicked */
        menu.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                new Menu(); // Runs Menu
            }
        });

        
        GUI.win.setSize(630, 350);                    // Set window size
        GUI.win.setMinimumSize(new Dimension(630, 350)); // Set window min size
        GUI.win.setMaximumSize(new Dimension(630, 350)); // Set window max size
    }
    
    
    public static boolean getNewData() { return isNewData; }
    
    
    /* Creates label objects */
    private JLabel title = new JLabel("DATA INPUT");
    private JLabel x1 = new JLabel("X1: No. of bathrooms:");
    private JLabel x2 = new JLabel("X2: Area of the site (1,000’s square feet):");
    private JLabel x3 = new JLabel("X3: Size of living space (1,000’s square feet):");
    private JLabel x4 = new JLabel("X4: No. of garages:");
    private JLabel x5 = new JLabel("X5: No. of rooms:");
    private JLabel x6 = new JLabel("X6: No. of bedrooms:");
    private JLabel x7 = new JLabel("X7: Age of property (years):");
    private JLabel y = new JLabel("Y: Selling Price (£100,000’s):");
    private JLabel helpMsg = new JLabel("Separate each number with a comma (eg 1,2,3)");
    
    /* Creates textbox objects */
    private JTextField x1Input = new JTextField();
    private JTextField x2Input = new JTextField();
    private JTextField x3Input = new JTextField();
    private JTextField x4Input = new JTextField();
    private JTextField x5Input = new JTextField();
    private JTextField x6Input = new JTextField();
    private JTextField x7Input = new JTextField();
    private JTextField yInput = new JTextField();
    
    /* Creates button objects */
    private JButton menu = new JButton("Return to Menu");
    private JButton addVal = new JButton("Add Data");
    
    private static Boolean isNewData;
}

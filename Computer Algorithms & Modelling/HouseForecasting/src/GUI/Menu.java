
package GUI;

import java.awt.Container;
import java.awt.Dimension;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.SwingConstants;


public class Menu extends JFrame {

    public Menu() {
        Container window = GUI.win.getContentPane();
        GUI.win.setTitle("House Price Menu");

        window.removeAll(); // Clears window
        window.repaint();   // Remakes window
        
        /* Title */
        Dimension title_size = title.getPreferredSize();    // Creates and sets object time_size
        title.setBounds(0, 10, 280, title_size.height);     // Sets time bounds
        window.add(title);                                  // Add time label to window


        /* ========== Enter data button ========== */
        inputs.setBounds(40, 100, 200, 30); // Sets inputs bounds
        window.add(inputs);                 // Add inputs button to window

        inputs.addActionListener(new ActionListener() { // When power button clicked
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                new DataInputs(true);   // Runs DataInputs
            }
        });


        /* ========== Enter comparison data button ========== */
        comparison.setBounds(40, 135, 200, 30); // Sets comparison bounds
        window.add(comparison);                 // Add comparison button to window

        comparison.addActionListener(new ActionListener() { // When power button clicked
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                new DataInputs(false);   // Runs comparison
            }
        });


        /* ========== Results button ========== */
        results.setBounds(40, 170, 200, 30);    // Sets results bounds
        window.add(results);                    // Add results button to window
        
        /* Results button clicked */
        results.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                new Results(0);  // Runs Results
            }
        });


        /* ========== Close program button ========== */
        quit.setBounds(40, 205, 200, 30);   // Sets quit bounds
        window.add(quit);                   // Add quit button to window
        
        /* Quit button clicked */
        quit.addActionListener(new ActionListener() {   
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                GUI.win.dispatchEvent(new WindowEvent(GUI.win, WindowEvent.WINDOW_CLOSING));    // Close Window
            }
        });


        GUI.win.setSize(300, 300);                          // Set window size
        GUI.win.setMinimumSize(new Dimension(300, 300));    // Set window min size
        GUI.win.setMaximumSize(new Dimension(300, 300));    // Set window max size
        GUI.win.setVisible(true);                           // Make window visible
    }
    
    
    /* Declare objects */
    private JLabel title = new JLabel("HOUSE PRICE FORECASTING", SwingConstants.CENTER);    // Create label object title

    private JButton inputs = new JButton("Enter Data");                 // Create button object inputs
    private JButton comparison = new JButton("Enter Comparison Data");  // Create button object inputs
    private JButton results = new JButton("Show Results");              // Create button object results
    private JButton quit = new JButton("Close Program");                // Create button object quit
	
}


package GUI;

import java.awt.EventQueue;
import javax.swing.JFrame;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;


public class GUI  extends JFrame {
    
    private JFrame window = new JFrame("House Prices"); // Create frame object window
    public static JFrame win;
    
    public GUI() {
        GUI.win = window;
        
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
                } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | UnsupportedLookAndFeelException ex) {
                }

                window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);	// Stop program on exit
                window.setLayout(null);                                 // Set border layout
                window.pack();						// Set all frames
                window.setLocationRelativeTo(null);			// Set locations to null
                new Menu();						// Run menu
            }
        });
    }
    
    
}


package GUI;

import houseforecasting.Calc;
import java.awt.event.ActionListener;
import java.text.DecimalFormat;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;


public class Correlation {
    
    public Correlation() {
        //Container window = GUI.win.getContentPane();
        //GUI.win.setTitle("House Price Correlation");
        JFrame window = new JFrame();
        //window.removeAll(); // Clears window
        //window.repaint();   // Remakes window
        
        
        int[] best = Calc.orderGraphCorrel();
        
        text.setBounds(10, 5,(int)text.getPreferredSize().getWidth(), 20);
        window.add(text);
        
        pos1.setText("1. " + Results.getNames(best[0]) + " with a correlation of " + df.format(Calc.getR_Sqrd(best[0]) * 100) + "%");
        pos1.setBounds(10, 30, (int)pos1.getPreferredSize().getWidth(), 20);
        window.add(pos1);
        
        pos2.setText("2. " + Results.getNames(best[1]) + " with a correlation of " + df.format(Calc.getR_Sqrd(best[1]) * 100) + "%");
        pos2.setBounds(10, 50, (int)pos2.getPreferredSize().getWidth(), 20);
        window.add(pos2);
        
        pos3.setText("3. " + Results.getNames(best[2]) + " with a correlation of " + df.format(Calc.getR_Sqrd(best[2]) * 100) + "%");
        pos3.setBounds(10, 70, (int)pos3.getPreferredSize().getWidth(), 20);
        window.add(pos3);
        
        pos4.setText("4. " + Results.getNames(best[3]) + " with a correlation of " + df.format(Calc.getR_Sqrd(best[3]) * 100) + "%");
        pos4.setBounds(10, 90, (int)pos4.getPreferredSize().getWidth(), 20);
        window.add(pos4);
        
        pos5.setText("5. " + Results.getNames(best[4]) + " with a correlation of " + df.format(Calc.getR_Sqrd(best[4]) * 100) + "%");
        pos5.setBounds(10, 110, (int)pos5.getPreferredSize().getWidth(), 20);
        window.add(pos5);
        
        pos6.setText("6. " + Results.getNames(best[5]) + " with a correlation of " + df.format(Calc.getR_Sqrd(best[5]) * 100) + "%");
        pos6.setBounds(10, 130, (int)pos6.getPreferredSize().getWidth(), 20);
        window.add(pos6);
        
        pos7.setText("7. " + Results.getNames(best[6]) + " with a correlation of " + df.format(Calc.getR_Sqrd(best[6]) * 100) + "%");
        pos7.setBounds(10, 150, (int)pos7.getPreferredSize().getWidth(), 20);
        window.add(pos7);
        
        
        
        
        /* Return button */
        results.setBounds(5, 180, 150, 30);    // Sets menu bounds
        window.add(results);                   // Add menu button to window
        
        /* Menu button clicked */
        results.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                window.dispose();
            }
        });
        
        window.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);	// Stop program on exit
                window.setLayout(null);                                 // Set border layout
                window.pack();						// Set all frames
                window.setLocationRelativeTo(null);			// Set locations to null
                
        window.setVisible(true);                           // Make window visible
        window.setSize(400, 255);                          // Set window size
        //GUI.win.setMinimumSize(new Dimension(400, 200));    // Set window min size
        //GUI.win.setMaximumSize(new Dimension(400, 200));    // Set window max size
    }
    
    
    /* Creates button objects */
    private JButton results = new JButton("Return to Results");
    
    private JLabel text = new JLabel("Each graph is ordered by correlation from best to worst");
    private JLabel pos1 = new JLabel();
    private JLabel pos2 = new JLabel();
    private JLabel pos3 = new JLabel();
    private JLabel pos4 = new JLabel();
    private JLabel pos5 = new JLabel();
    private JLabel pos6 = new JLabel();
    private JLabel pos7 = new JLabel();
    
    private DecimalFormat df = new DecimalFormat("#.####");
}

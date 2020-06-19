
package GUI;

import javax.swing.JFrame;
import javax.swing.JOptionPane;


public class PopUp {

    public PopUp(String msg) {
        /* Displays sucess or error message */
        if (msg.equals("Data has been added"))
            JOptionPane.showMessageDialog(popUp, msg, "Success!", JOptionPane.PLAIN_MESSAGE);
        else 
            JOptionPane.showMessageDialog(popUp, msg, "Error!", JOptionPane.ERROR_MESSAGE);
    }
    
    private JFrame popUp = new JFrame();  
}

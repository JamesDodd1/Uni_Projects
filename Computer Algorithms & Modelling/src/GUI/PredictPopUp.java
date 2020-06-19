/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GUI;

import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 *
 * @author jamesdodd
 */
public class PredictPopUp {
    
    private JFrame predPopUp = new JFrame();  
    
    public PredictPopUp(String msg, String graphName, double xInput, double slope, double yIntercept) {
        double yPred = (slope * xInput) + yIntercept;
        
        /* Displays sucess or error message */
        if (msg.equals("predicting")) {
            output = "For " + graphName + " when X is " + xInput + ", Y is predicted to be " + yPred;
            JOptionPane.showMessageDialog(predPopUp, output, "Success!", JOptionPane.PLAIN_MESSAGE);
        }
        else 
            JOptionPane.showMessageDialog(predPopUp, msg, "Error!", JOptionPane.ERROR_MESSAGE);
    }
    
    private String output;
    
}

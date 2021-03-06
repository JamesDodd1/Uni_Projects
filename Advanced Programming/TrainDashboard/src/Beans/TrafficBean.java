
package Beans;

import BridgePattern.MakeTraffic;
import java.awt.BasicStroke;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import javax.swing.JPanel;


public class TrafficBean extends JPanel {

    /* Declare variables */
    private boolean value; 
    private int radius, padding; 
    private MakeTraffic traffic;
    
    
    public TrafficBean() {
        this(50, 10, false);
    }
    
    
    public TrafficBean(int radius, int padding, boolean value) {
        this.radius = radius;
        this.padding = padding;
        this.value = value;
        
        setPreferredSize(new Dimension(2 * (radius + padding), 2 * (radius + padding)));
    }
    
    
    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D) g; // Creates Graphics object
        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        g2.setStroke(new BasicStroke(3, BasicStroke.CAP_ROUND, 0));
        
        drawObject(g2); // Draw a traffic light
    }
    
    
    /* Draws a traffic light */
    private void drawObject(Graphics2D g2) {
        // Creates a traffic light
        traffic = new MakeTraffic(g2, radius, padding, value);
    }
    
    
    /* Set method */
    public void setValue(boolean value) {
        this.value = value; // Sets value
        repaint();          // Redraws the panel
    }
    

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 300, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents


    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}


package Beans;

import BridgePattern.MakeBar;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.RenderingHints;


public class BarBean extends LayoutBean implements DashboardBean {
    
    /* Declare variables */
    private int barLength, barHeight; 
    private MakeBar bar;
    
    
    public BarBean() {
        this(30, 200, 8, 0, 100, 0);
    }
    
    
    public BarBean(int length, int height, int padding, int minValue, int maxValue, int value) {
        super(padding, minValue, maxValue, value);

        this.barLength = length;
        this.barHeight = height;
        
        setPreferredSize(new Dimension(barLength + (2 * padding), barHeight + (2 * padding)));
    }
    
    
    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D) g; // Creates Graphics object
        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);

        drawObject(g2); // Draw the vertical bar
    }
    
    
    /* Draws a vertical bar */
    @Override
    public void drawObject(Graphics2D g2) {
        // Creates a vertical bar
        bar = new MakeBar(g2, padding, barLength, barHeight, value, maxValue, "RedToYellow");
    }
    
    
    /* Get/Set methods */
    @Override 
    public int getMaxValue() { return maxValue; }
    
    @Override 
    public int getMinValue() { return minValue; }
    
    @Override 
    public int getValue() { return value; }
    
    @Override
    public void setValue(int value) {
        value = value < minValue ? (int) minValue : value; // Stops value exceeding min limit
        value = value > maxValue ? (int) maxValue : value; // Stops value exceeding max limit
        this.value = value;
        
        repaint(); // Redraws the panel
    }
    

    /**
     * This method is called from within the constructor to initialise the form.
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

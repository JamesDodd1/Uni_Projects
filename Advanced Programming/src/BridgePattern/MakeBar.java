
package BridgePattern;

import java.awt.BasicStroke;
import java.awt.Graphics2D;
import java.awt.geom.Line2D;
import java.awt.geom.Rectangle2D;


public class MakeBar implements DashboardObjects {
    
    /* Declare variables */
    private Graphics2D g2;
    private Rectangle2D barx;
    private int value, padding, length, height;
    private double maxValue;
    
    
    public MakeBar(Graphics2D g2, int padding, int length, int height, int value, double maxValue, String colour) {
        this.g2 = g2;
        this.padding = padding;
        this.length = length;
        this.height = height;
        this.value = value;
        this.maxValue = maxValue;
        
        createObject(colour); // Create a bar
    }
    
    
    /* Creates bar */
    @Override 
    public void createObject(String colour) {
        // Draws the bar.  First 10% is coloured red, the fnal 30% is yellow.  Inbetween it gradually turns from red to yellow
        barx = new Rectangle2D.Double(padding, padding, length, height);
        setColour("RedToYellow");
        g2.fill(barx);
        
        // Draws value indicator 
        g2.setStroke(new BasicStroke(height/40, BasicStroke.CAP_SQUARE, 0));
        setColour("Gray");
        Line2D valueIndicator = new Line2D.Double(padding / 2F, padding + (height * (100 - value) / maxValue), length+ (padding * 1.5F), padding + (height * (100 - value) / maxValue));
        g2.draw(valueIndicator);
    }
    
    
    /* Sets bar colour */
    @Override
    public void setColour(String colour) {
        Colour fillColour = new Colour(barx, g2, colour);
        g2 = fillColour.getColour();
    }
}

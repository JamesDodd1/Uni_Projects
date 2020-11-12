
package BridgePattern;

import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.geom.Ellipse2D;


public class MakeTraffic implements DashboardObjects {
    
    /* Declare variables */
    private Graphics2D g2;
    private boolean value; 
    private int radius, padding; 
    
    
    public MakeTraffic(Graphics2D g2, int radius, int padding, boolean value) {
        this.g2 = g2;
        this.radius = radius;
        this.padding = padding;
        
        // Sets traffic light with set colour 
        if (value)
            createObject("Green");
        else
            createObject("Red");
    }
    
    
    @Override
    public void createObject(String colour) {
        // Draw outer circle
        Ellipse2D circleEdge = new Ellipse2D.Double((padding), (padding), radius * 2, radius * 2);
        setColour("Black");
        g2.fill(circleEdge);
        
        // Draw inner circle
        Ellipse2D circleFill = new Ellipse2D.Double((int)(padding * 1.3), (int)(padding * 1.3), (int)((radius * 2) * 0.94), (int)((radius * 2) * 0.94));
        setColour(colour);
        g2.fill(circleFill);
        
    }
    
    
    /* Sets dial colour */
    @Override
    public void setColour(String colour) { 
        Colour fillColour = new Colour(g2, colour);
        g2 = fillColour.getColour();
    }
}


package BridgePattern;

import java.awt.Color;
import java.awt.GradientPaint;
import java.awt.Graphics2D;
import java.awt.geom.Arc2D;
import java.awt.geom.Rectangle2D;


public class Colour implements SetColour {
    
    /* Declare variables */
    private Graphics2D g2;
    private Rectangle2D barx;
    private Arc2D arc;
    
    
    /* For generic colouring */
    public Colour(Graphics2D g2, String colour) {
        this.g2 = g2;
        
        setColour(colour); // Set the colour
    }
    
    
    /* For fuel bar */
    public Colour(Rectangle2D barx, Graphics2D g2, String colour) {
        this.barx = barx;
        this.g2 = g2;
        
        setColour(colour); // Set the colour
    }
    
    
    /* For dial arc */
    public Colour(Arc2D arc, Graphics2D g2, String colour) {
        this.arc = arc;
        this.g2 = g2;
        
        setColour(colour); // Set the colour
    }
    
    
    /* Set colour to the graphics */
    @Override
    public void setColour(String colour) {
        switch (colour) {
            case "Black" :
                g2.setColor(Color.BLACK);
                break;  
            case "Red" :
                g2.setColor(Color.RED);
                break;
            case "Green" :
                g2.setColor(Color.GREEN);
                break;
            case "Gray" :
                g2.setPaint(Color.GRAY);
                break;
            case "BlackToRed" : // Black on the left, red on the right, blends together at 60% along from the left
                GradientPaint blueToBlack = new GradientPaint((float) arc.getHeight() * 0.6F, 0, Color.BLACK, (float) arc.getHeight(), 0, Color.RED);
                g2.setPaint(blueToBlack);
                break;
            case "RedToYellow" : // Red on the bottom, yellow on the top, blends together at 70% down from the top
                GradientPaint redToYellow = new GradientPaint(0, (float) barx.getHeight() * 0.7F, Color.YELLOW, 0, (float) barx.getHeight(), Color.RED);
                g2.setPaint(redToYellow);
                break;
            default :
                g2.setColor(Color.BLACK);
        }
    }
    
    
    @Override
    public Graphics2D getColour() { return g2; }
}

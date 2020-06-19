
package BridgePattern;

import static Beans.DialBean.DIAL_EXTENT_DEGREES;
import static Beans.DialBean.DIAL_START_OFFSET_DEGREES;
import java.awt.Graphics2D;
import java.awt.geom.Arc2D;
import java.awt.geom.Ellipse2D;
import java.awt.geom.Line2D;
import java.awt.geom.Point2D;


public class MakeDial implements DashboardObjects {
    
    /* Declares variables */
    private Graphics2D g2;
    private int radius, padding, value;
    private double maxValue, handLength; // Length of indicator hand
    
    
    public MakeDial(Graphics2D g2, int radius, int padding, int value, double maxValue, String colour) {
        this.g2 = g2;
        this.radius = radius;
        this.padding = padding;
        this.value = value;
        this.maxValue = maxValue;
        this.handLength = radius * 0.9; // Hand length is set to 90% of radius
        
        createObject(colour); // Create a dial
    }
    
    
    /* Creates dial */
    @Override 
    public void createObject(String colour) {
        // Draw centre circle
        Ellipse2D circle = new Ellipse2D.Double((radius + padding) - 5, (radius + padding) - 5, 10, 10);
        setColour("Black");
        g2.fill(circle);
        
        
        // Draws the dial circle
        Arc2D arc = new Arc2D.Double(padding, padding, 2 * radius, 2 * radius, DIAL_START_OFFSET_DEGREES, DIAL_EXTENT_DEGREES, Arc2D.Double.OPEN);
        setColour(arc, colour);
        g2.draw(arc);
        
        
        double dialStart = DIAL_START_OFFSET_DEGREES + DIAL_EXTENT_DEGREES; // Beginning of dial
        double notchDif = DIAL_EXTENT_DEGREES / 5;                          // Difference between each notch
        
        // Draws the start/end lines
        drawNotch(g2, Math.toRadians(dialStart)); // Start
        drawNotch(g2, Math.toRadians(dialStart - (notchDif * 1)));
        drawNotch(g2, Math.toRadians(dialStart - (notchDif * 2)));
        drawNotch(g2, Math.toRadians(dialStart - (notchDif * 3)));
        drawNotch(g2, Math.toRadians(dialStart - (notchDif * 4)));
        drawNotch(g2, Math.toRadians(dialStart - (notchDif * 5))); // End
        
        
        // Draws the hand 
        double angle = Math.toRadians(225 - (value * (DIAL_EXTENT_DEGREES / maxValue))); // Angle hand to be drawn at
        setColour("BLACK");
        drawHand(g2, angle, handLength);
    }
    
    
    /* Draws a notch on the dial */
    private void drawNotch(Graphics2D g2, double angle) {
        // Calculate end of Dial
        Point2D edge = new Point2D.Double((radius + padding) + radius * Math.cos(angle), (radius + padding) - radius * Math.sin(angle));
        
        // Calculate beginning of dial 
        Point2D centre = new Point2D.Double((radius + padding) + ((radius + padding) * .7) * Math.cos(angle), (radius + padding) - ((radius + padding) * .7) * Math.sin(angle));
        
        // Draws the line
        g2.draw(new Line2D.Double(edge, centre));
    }
    
    
    /* Draws a hand for the dial */
    private void drawHand(Graphics2D g2, double angle, double handLength) {
        // Calculate the outer end of the hand
        Point2D edge = new Point2D.Double((radius + padding) + handLength * Math.cos(angle), (radius + padding) - handLength * Math.sin(angle));
        
        // Calculate the centre 
        Point2D centre = new Point2D.Double(radius + padding, radius + padding);
        
        // Draw the line
        g2.draw(new Line2D.Double(centre, edge));
    }
    
    
    /* Sets dial colour */
    @Override
    public void setColour(String colour) { 
        Colour fillColour = new Colour(g2, colour);
        g2 = fillColour.getColour();
    }
    
    public void setColour(Arc2D arc, String colour) { 
        Colour fillColour = new Colour(arc, g2, colour);
        g2 = fillColour.getColour();
    }
}

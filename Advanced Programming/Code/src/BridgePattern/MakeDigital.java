
package BridgePattern;

import java.awt.Graphics2D;
import java.awt.geom.Line2D;
import java.awt.geom.Point2D;


public class MakeDigital implements DashboardObjects {
    
    /* Declare variables */
    private Graphics2D g2;
    private int value;
    
    private int number[];
    
    private final static int zero[] = { 1, 1, 1, 1, 1, 0, 1};
    private final static int one[] = { 0, 0, 1, 1, 0, 0, 0 };
    private final static int two[] = { 0, 1, 1, 0, 1, 1, 1 };
    private final static int three[] = { 0, 0, 1, 1, 1, 1, 1};
    private final static int four[] = { 1, 0, 1, 1, 0, 1, 0 };
    private final static int five[] = { 1, 0, 0, 1, 1, 1, 1 };
    private final static int six[] = { 1, 1, 0, 1, 1, 1, 1 };
    private final static int seven[] = { 0, 0, 1, 1, 1, 0, 0 };
    private final static int eight[] = { 1, 1, 1, 1, 1, 1, 1};
    private final static int nine[] = { 1, 0, 1, 1, 1, 1, 1};
    
    
    public MakeDigital(Graphics2D g2, int value) {
        this.g2 = g2;
        this.value = value;
        
        createObject("Black");
    }
    
    
    @Override
    public void createObject(String colour) {
        // Gets number for each unit value
        int hundredNum = (int)(value / 100);    // Hundreds value
        int tenNum = (int)((value % 100) / 10); // Tens value
        int singleNum = (int)(value % 10);      // Singles value
        
        setColour(colour); 
        
        // Draws hundreds number
        setNumber(hundredNum);
        drawNumber(g2, new Point2D.Double(5, 5), number);
        
        // Draws tens number
        setNumber(tenNum);
        drawNumber(g2, new Point2D.Double(41, 5), number);
        
        // Draws singles number
        setNumber(singleNum);
        drawNumber(g2, new Point2D.Double(77, 5), number);
        
    }
    
    
    /* Draws each number */
    private void drawNumber(Graphics2D g2, Point2D numLoc, int number[]) {
        // Top left vertical line
        if (number[0] == 1) 
            g2.draw(new Line2D.Double(new Point2D.Double(numLoc.getX() + 5, numLoc.getY() + 5), new Point2D.Double(numLoc.getX() + 5, numLoc.getY() + 30)));    
        
        // Bottom left vertical line
        if (number[1] == 1) 
            g2.draw(new Line2D.Double(new Point2D.Double(numLoc.getX() + 5, numLoc.getY() + 30), new Point2D.Double(numLoc.getX() + 5, numLoc.getY() + 55)));   
        
        // Top right vertical line
        if (number[2] == 1) 
            g2.draw(new Line2D.Double(new Point2D.Double(numLoc.getX() + 30, numLoc.getY() + 5), new Point2D.Double(numLoc.getX() + 30, numLoc.getY() + 30)));  
        
        // Bottom right vertical line
        if (number[3] == 1) 
            g2.draw(new Line2D.Double(new Point2D.Double(numLoc.getX() + 30, numLoc.getY() + 30), new Point2D.Double(numLoc.getX() + 30, numLoc.getY() + 55))); 
        
        // Top horizontal line
        if (number[4] == 1) 
            g2.draw(new Line2D.Double(new Point2D.Double(numLoc.getX() + 5, numLoc.getY() + 5), new Point2D.Double(numLoc.getX() + 30, numLoc.getY() + 5)));    
        
        // Middle horizontal line
        if (number[5] == 1) 
            g2.draw(new Line2D.Double(new Point2D.Double(numLoc.getX() + 5, numLoc.getY() + 30), new Point2D.Double(numLoc.getX() + 30, numLoc.getY() + 30)));  
        
        // Bottom horizontal line
        if (number[6] == 1) 
            g2.draw(new Line2D.Double(new Point2D.Double(numLoc.getX() + 5, numLoc.getY() + 55), new Point2D.Double(numLoc.getX() + 30, numLoc.getY() + 55)));  
    }
    
    
    /* Sets gets array to diplay number */
    private void setNumber(int value) {
        switch (value) {
            case 0:
                number = zero;
                break;
            case 1:
                number = one;
                break;
            case 2:
                number = two;
                break;
            case 3:
                number = three;
                break;
            case 4:
                number = four;
                break;
            case 5:
                number = five;
                break;
            case 6:
                number = six;
                break;
            case 7:
                number = seven;
                break;
            case 8:
                number = eight;
                break;
            case 9:
                number = nine;
                break;
            default:
                break;
        }
    }
    
    
    /* Sets bar colour */
    @Override
    public void setColour(String colour) {
        Colour fillColour = new Colour(g2, colour);
        g2 = fillColour.getColour();
    }
}

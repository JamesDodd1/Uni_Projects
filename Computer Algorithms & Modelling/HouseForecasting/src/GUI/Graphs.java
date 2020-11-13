
package GUI;

import houseforecasting.Calc;
import java.awt.Color;
import java.awt.FontMetrics;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Point;
import java.awt.RenderingHints;
import java.awt.Stroke;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JPanel;


public class Graphs extends JPanel {
    

    public Graphs(List<Double> xPlot, List<Double> yPlot){
        this.xPlot = xPlot;
        this.yPlot = yPlot;
    }
    
    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D) g;

        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        
        
        int[] bestGraph = Calc.orderGraphCorrel();
        if (bestGraph[0] == Results.getX_Input()) 
            isBestGraph = true;
        
        
        /* X scale for scatter points */
        if (getCompXMax() > getXMax()) {
            if (userX != null) {
                if (getCompXMax() < getUserXMax()) {
                    xMax = getUserXMax();
                    xScale = xAxisLen / xMax;
                }
                else {
                    xMax = getCompXMax();
                    xScale = xAxisLen / xMax;
                }
            }
            else {
                xMax = getCompXMax();
                xScale = xAxisLen / xMax;
            }
        }
        else {
            if (userX != null) {
                if (getXMax() < getUserXMax()) {
                    xMax = getUserXMax();
                    xScale = xAxisLen / xMax;
                }
                else {
                    xMax = getXMax();
                    xScale = xAxisLen / xMax;
                }
            }
            else {
                xMax = getXMax();
                xScale = xAxisLen / xMax;
            }
        }
        
        
        /* Y scale for scatter points */
        if (getCompYMax() > getYMax()) {
            if (userY != null) {
                if (getCompYMax() < getUserYMax()) {
                    yMax = getUserYMax();
                    yScale = yAxisLen / yMax;
                }
                else {
                    yMax = getCompYMax();
                    yScale = yAxisLen / yMax;
                }
            }
            else {
                yMax = getCompYMax();
                yScale = yAxisLen / yMax;
            }
        }
        else {
            if (userY != null) {
                if (getYMax() < getUserYMax()) {
                    yMax = getUserYMax();
                    yScale = yAxisLen / yMax;
                }
                else {
                    yMax = getYMax();
                    yScale = yAxisLen / yMax;
                }
            }
            else {
                yMax = getYMax();
                yScale = yAxisLen / yMax;
            }
        }
        
        
        /* Sets graph points */
        for(int i = 0; i < Calc.getNum(); i++) {
            
            int x1 = (int)((xPlot.get(i) * xScale) + xCoord + labelPadding);    // Finds end of graph x coord
            int y1 = (int)(yAxisLen - (yPlot.get(i) * yScale) + yCoord);        // Finds end of graph y coord
            
            graphPoints.add(new Point(x1, y1));
        }
        
        
        List<Double> bestX = Calc.getXComp(bestGraph[0]);
        for (int i = 1; i < Calc.getCompNum(); i++) {
            
            int x2 = (int)((bestX.get(i) * xScale) + xCoord + labelPadding);
            int y2 = (int)((yAxisLen - ((Calc.getSlope(bestGraph[0]) * bestX.get(i)) + Calc.getY_Intercept(bestGraph[0])) * yScale) + yCoord);
            
            compPoints.add(new Point(x2, y2));
        }
        
        
        /* Sets graph background */
        g2.setColor(Color.WHITE);
        g2.fillRect(xCoord + labelPadding, yCoord, xAxisLen, yAxisLen);
        
        
        /* Draws the graph */
        drawAxis(g2);
        AxisTitle(g2);
        xAxisLabels(g2);
        yAxisLabels(g2);
        
        
        /* Adds plot points to graph */
        Stroke plotStyle = g2.getStroke();
        g2.setStroke(plotStyle);
        setPlot(g2, graphPoints, pointColour);  // Draws each plot point
        if (isBestGraph)
            setPlot(g2, compPoints, compColour); // Draws each predicted plot point
        
        if (userPoints.isEmpty() == false) 
            setPlot(g2, userPoints, userColour);  // Draws each predicted plot point
        
        
        drawRegressionLine(g2, xScale, yScale, pointColour); // Draws line of regression
    }
    
    
    private void drawAxis(Graphics2D g2) {
        g2.setColor(Color.BLACK);
        
        /* Y axis line */
        g2.drawLine(xCoord + labelPadding, yCoord, xCoord + labelPadding, yCoord + yAxisLen); 
        
        /* X axis line */
        g2.drawLine(xCoord + labelPadding, yCoord + yAxisLen, xCoord + labelPadding + xAxisLen, yCoord + yAxisLen);  
    }
    
    
    private void AxisTitle(Graphics2D g2) {
        /* Set axis title */
        String yAxisTitle = "Selling Price (£100,000’s)";
        String xAxisTitle = Results.getX_Name();
        
        g2.setColor(Color.BLACK);
        
        FontMetrics text = g2.getFontMetrics();
        int xTitleWidth = text.stringWidth(xAxisTitle);
        int yTitleWidth = text.stringWidth(yAxisTitle);
        
        g2.drawString(xAxisTitle, xCoord + labelPadding + (xAxisLen / 2) - (xTitleWidth / 2), yCoord + labelPadding + yAxisLen + 40);
        rotateText(g2, xCoord - 30, yCoord + (yAxisLen / 2) + (yTitleWidth / 2), 270, yAxisTitle);
    }
    
    
    private void xAxisLabels(Graphics2D g2) {
        /* X axis labels */
        for (int i = 0; i <= numOfAxisNotch; i++) {
            int x0 = xCoord + labelPadding + ((i * xAxisLen) / numOfAxisNotch);          // X notches starting x coord
            int x1 = x0;
            int y0 = yCoord + labelPadding + yAxisLen;   // X Label starting y coord
            int y1 = y0 - pointWidth;                                   // Length of notches

            if (xPlot.size() > 0) {
                /* Guide line */
                g2.setColor(gridColour);
                g2.drawLine(x0, y0, x1, yCoord);    // Draws guide line

                /* X Axis numbers */
                g2.setColor((Color.BLACK));
                String xLabel = df.format(((double)((xMax * ((i * 1.0) / numOfAxisNotch)) * 100))/ 100.0) + "";     // Creates label

                FontMetrics text = g2.getFontMetrics();
                int labelWidth = text.stringWidth(xLabel);                              // Sets label width
                g2.drawString(xLabel, x0 - labelWidth / 2, y0 + text.getHeight() + 3);  // Draws label text
            }
            g2.drawLine(x0, y0, x1, y1);    // Draws notch lines
        }
    }
    
    
    private void yAxisLabels(Graphics2D g2) {
        /* Y axis labels */
        for (int i = 0; i < numOfAxisNotch + 1; i++) {
            int x0 = xCoord + labelPadding;                                 // Y notches starting x coord
            int x1 = pointWidth + xCoord + labelPadding;                    // Y notches width
            int y0 = yCoord + yAxisLen - ((i * yAxisLen) / numOfAxisNotch); // Y notches location
            int y1 = y0;
            
            if(yPlot.size() > 0){
                /* Guide line */
                g2.setColor(gridColour);
                g2.drawLine(x0, y0, xCoord + labelPadding + xAxisLen, y1);  // Draws guide line
                
                g2.setColor(Color.BLACK);
                String yLabel = df.format(((double)((yMax * ((i * 1.0) / numOfAxisNotch)) * 100))/ 100.0) + "";  // Creates label

                FontMetrics text = g2.getFontMetrics();
                int labelWidth = text.stringWidth(yLabel);                                      // Sets label width
                g2.drawString(yLabel, x0 - labelWidth - 6, y0 + (text.getHeight() / 2) - 3);    // Draws label text

            }
                g2.drawLine(x0, y0, x1, y1);    // Draws notch line

        }
    }
    
    
    private void setPlot(Graphics2D g2, List<Point> graph, Color colour) {
        /* Plot data */
        g2.setColor(colour);
        
        for (int i = 0; i < graph.size(); i++) {
            int x = graph.get(i).x - pointWidth / 2;  // Set x coord
            int y = graph.get(i).y - pointWidth / 2;  // Set y coord
            int plotWid = pointWidth;                 // Set plot width
            int plotHigh = pointWidth;                // Set plot height
            g2.fillOval(x, y, plotWid, plotHigh);     // Draw plot point
        }
    }
    
    
    private void drawRegressionLine(Graphics2D g2, double xScale, double yScale, Color colour) {
        g2.setColor(colour);
        
        int x = Results.getX_Input();
        
        /* Plot line of regression */
        double yInt = Calc.getY_Intercept(x);
        double slopes = Calc.getSlope(x);
        
        double xFirst = xCoord + labelPadding + (getXMin() * xScale);
        double xLast = xCoord + labelPadding + (xMax * xScale);
        
        double yFirst = yCoord + yAxisLen - (((slopes * getXMin()) + yInt) * yScale);
        double yLast = yCoord + yAxisLen - (((slopes * xMax) + yInt) * yScale);
        
        g2.drawLine((int)xFirst, (int)yFirst, (int)xLast, (int)yLast);
    }
    
    
    private double getXMin() {
        double minX = 0;
        
        /* Loop for each iteration of xPlot */
        for (Double x : xPlot) {
            minX = Math.min(minX, x);   // Find lowest X
        }
        
        return minX;
    }


    private double getXMax() {
        double maxX = 0;
        
        /* Loop for each iteration of xPlot */
        for (Double x : xPlot) {
            maxX = Math.max(maxX, x);   // Find largest X
        }
        
        return maxX;
    }
    
    
    private double getYMin() {
        double minY = 0;
        
        /* Loop for each iteration of yPlot */
        for (Double y : yPlot) {
            minY = Math.min(minY, y);   // Find lowest Y
        }
        
        return minY;
    }


    private double getYMax() {
        double maxY = 0;
        
        /* Loop for each iteration of score */
        for (Double y : yPlot) {
            maxY = Math.max(maxY, y);   // Find largest Y
        }
        
        return maxY;
    }
    
    
    private double getUserXMax() {
        double maxX = 0;
        
        /* Loop for each iteration of userX */
        for (Double x : userX) {
            maxX = Math.max(maxX, x);   // Find largest Y
        }
        
        return maxX;
    }
    
    
    private double getUserYMax() {
        double maxY = 0;
        
        /* Loop for each iteration of userY */
        for (Double y : userY) {
            maxY = Math.max(maxY, y);   // Find largest Y
        }
        
        return maxY;
    }
    
    
    private double getCompXMax() {
        if (isBestGraph) {
            int[] bestGraph = Calc.orderGraphCorrel();
            List<Double> bestX = Calc.getXComp(bestGraph[0]);

            double maxX = 0;

            /* Loop for each iteration of userX */
            for (Double x : bestX) {
                maxX = Math.max(maxX, x);   // Find largest Y
            }

            return maxX;
        }
        return 0;
    }
    
    
    private double getCompYMax() {
        if (isBestGraph) {
            List<Double> bestY = Calc.getYComp();

            double maxY = 0;

            /* Loop for each iteration of userX */
            for (Double y : bestY) {
                maxY = Math.max(maxY, y);   // Find largest Y
            }

            return maxY;
        }
        return 0;
    }
    
    
    private static void rotateText(Graphics2D g2, double x, double y, int angle, String text) {    
        g2.translate((float)x,(float)y);
        g2.rotate(Math.toRadians(angle));
        g2.drawString(text,0,0);
        g2.rotate(-Math.toRadians(angle));
        g2.translate(-(float)x,-(float)y);
    }   
    
    
    public static void addUserX(int graphType, double x) {
        double yIntercept = Calc.getY_Intercept(graphType);
        double slope = Calc.getSlope(graphType);
        
        double y = (slope * x) + yIntercept;
        
        userX.add(x);
        userY.add(y);

        int x1 = (int)((x * xScale) + xCoord + labelPadding);   // Finds end of graph x coord
        int y1 = (int)(yAxisLen - (y * yScale) + yCoord);       // Finds end of graph y coord
        
        userPoints.add(new Point(x1, y1));
    }
    
    
    public static void clearPlots() {
        graphPoints.clear();
        compPoints.clear();
        userPoints.clear();
    }
    
    
    /* Declarations */
    private static List<Double> xPlot;
    private static List<Double> yPlot;
    
    private static List<Double> userX = new ArrayList<>();
    private static List<Double> userY = new ArrayList<>();
    
    private static List<Point> graphPoints = new ArrayList<>();
    private static List<Point> compPoints = new ArrayList<>();
    private static List<Point> userPoints = new ArrayList<>();
    
    private static int labelPadding = 12;  // Space for labels
    private static int numOfAxisNotch = 4; // Number of notches on axis
    private static int pointWidth = 10;    // Plot point size
    private static int xCoord = 435;       // X starting location
    private static int yCoord = 50;        // Y starting location
    private static int xAxisLen = 400;
    private static int yAxisLen = 150;
    
    private static double xScale;
    private static double yScale;
    private static double xMax;
    private static double yMax;
    
    private static boolean isBestGraph = false;
    
    private Color gridColour = new Color(200, 200, 200, 200);    // Colour light grey
    private Color pointColour = new Color(255, 0, 255);          // Colour pink
    private Color compColour = new Color(0, 0, 255);             // Colour blue
    private Color userColour = new Color(0, 255, 0);             // Colour green
    
    private DecimalFormat df = new DecimalFormat("#.##");
}

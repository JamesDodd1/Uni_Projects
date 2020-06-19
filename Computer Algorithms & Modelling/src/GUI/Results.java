
package GUI;

import houseforecasting.Calc;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.event.ActionListener;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.table.DefaultTableModel;


public class Results extends JFrame {
    
    public Results(int startGraph) {
        Container window = GUI.win.getContentPane();
        GUI.win.setTitle("House Price Results");
        
        window.removeAll(); // Clears window
        window.repaint();   // Remakes window
        
        
        /* ComboBox */
        select.setBounds(5, 5, 200, 30);  // Sets select bounds
        GUI.win.add(select);                                             // Adds select combobox to window
        select.setSelectedIndex(startGraph);                            // Sets combobox
        select.setEditable(false);                                      // Unable to be edited
        
        
        /* Update button */
        update.setBounds(210, 5, 150, 30);  // Sets update bounds
        window.add(update);                 // Adds update button to window
        
        /* Update button clicked */
        update.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                Graphs.clearPlots();
                getComboBoxData();
                new Results(xIn);
            }
        });
        
        
        /* Predict points */
        int labelWidth = (int)predLabel.getPreferredSize().getWidth();
        predLabel.setBounds(450, 10, labelWidth, 20);
        window.add(predLabel);
        
        predict.setBounds(455 + labelWidth, 5, 100, 30);
        window.add(predict);
        
        yPredict.setBounds(560 + labelWidth, 5, 150, 30);
        window.add(yPredict);
        
        /* yPredict button clicked */
        yPredict.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                Graphs.clearPlots();
                slope = Calc.getSlope(xIn);
                yIntercept = Calc.getY_Intercept(xIn);
                String msg = predYCheck();
                
                new PredictPopUp(msg, xName, xTextbox, slope, yIntercept);
                Graphs.addUserX(xIn, xTextbox);
                new Results(xIn);
            }
        });
        
        
        getComboBoxData();
        
        
        /* Creates tables and graphs */
        tableB(xIn);
        tableC(xIn);
        tableD(xIn);
        tableE(xIn);
        graph(xInput);
        
        
        /* Correlation button */
        compare.setBounds(210, 345, 150, 30);  // Sets compare bounds
        window.add(compare);                   // Add menu compare to window
        
        /* Correlation button clicked */
        compare.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                Graphs.clearPlots();
                new Correlation(); // Runs Correlation
            }
        });
        
        
        /* Return button */
        menu.setBounds(5, 345, 150, 30);    // Sets menu bounds
        window.add(menu);                   // Add menu button to window
        
        /* Menu button clicked */
        menu.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent e) {
                Graphs.clearPlots();
                new Menu(); // Runs Menu
            }
        });
        
        
        
        GUI.win.setSize(880, 420);                          // Set window size
        GUI.win.setMinimumSize(new Dimension(880, 420));    // Set window min size
        GUI.win.setMaximumSize(new Dimension(880, 420));    // Set window max size
    }
    
    
    private void getComboBoxData() {
        type = (String)select.getSelectedItem();
        // xInput.clear();
        
        switch(type) {
            case "Bathrooms":
                xIn = 0;
                xName = "No. of Bathrooms";
                xInput = Calc.getX1Array();
                break;
            case "Area":
                xIn = 1;
                xName = "Area of the Site (1,000’s Sq Ft)";
                xInput = Calc.getX2Array();
                break;
            case "Size":
                xIn = 2;
                xName = "Size of Living Space (1,000’s Sq Ft)";
                xInput = Calc.getX3Array();
                break;
            case "Garages":
                xIn = 3;
                xName = "No. of Garages";
                xInput = Calc.getX4Array();
                break;
            case "Rooms":
                xIn = 4;
                xName = "No. of Rooms";
                xInput = Calc.getX5Array();
                break;
            case "Bedroom":
                xIn = 5;
                xName = "No. of Bedrooms";
                xInput = Calc.getX6Array();
                break;
            case "Age":
                xIn = 6;
                xName = "Age of Property (Years)";
                xInput = Calc.getX7Array();
                break;
            default:
                xIn = 0;
                xName = "No. of Bathrooms";
                xInput = Calc.getX1Array();
                break;
        }
    }
    
    
    private void tableB(int xNum) {
        /* Set all variables to 4 dp */
        String num = df.format(Calc.getNum());
        String xMean = df.format(Calc.getX_Mean(xNum));
        String yMean = df.format(Calc.getY_Mean());
        String xVariance = df.format(Calc.getX_Variance(xNum));
        String yVariance = df.format(Calc.getY_Variance());
        String xStandDev = df.format(Calc.getX_StandDev(xNum));
        String yStandDev = df.format(Calc.getY_StandDev());
        
        /* Table B */
        String tableB_Head[] = { "", "X", "Y" };
        String tableB_data[][] = { 
            { "n", num, num },
            { "mean", xMean, yMean },
            { "variance", xVariance, yVariance },
            { "standard deviation", xStandDev, yStandDev }
        };
        
        // Table
        JTable tableB = new JTable(tableB_data,tableB_Head);
        
        // ScrollPane
        JScrollPane scrollPaneB = new JScrollPane(tableB);
        scrollPaneB.setBounds(380, 280, 300, 90);
        GUI.win.add(scrollPaneB);
    }
    
    
    private void tableC(int xNum) {
        /* Set all variables to 4 dp */
        String sumY = df.format(Calc.getSumY());
        String sumYY = df.format(Calc.getSumYY());
        String sumX = df.format(Calc.getSumX(xNum));
        String sumXX = df.format(Calc.getSumXX(xNum));
        String sumXY = df.format(Calc.getSumXY(xNum));
        
        /* Table C */
        String tableC_Head[] = { "", "" };
        String tableC_data[][] = { 
            { "∑X", sumX },
            { "∑X^2", sumXX },
            { "∑Y", sumY },
            { "∑Y^2", sumYY }, 
            { "∑XY", sumXY } 
        };
        
        // Table
        JTable tableC = new JTable(tableC_data,tableC_Head);
        
        // ScrollPane
        JScrollPane scrollPaneC = new JScrollPane(tableC);
        scrollPaneC.setBounds(700, 280, 150, 90);
        
        GUI.win.add(scrollPaneC);
    }
    
    
    private void tableD(int xNum) {
        /* Set all variables to 4 dp */
        String r = df.format(Calc.getR(xNum));
        String rSqrd = df.format(Calc.getR_Sqrd(xNum));
        String slope = df.format(Calc.getSlope(xNum));
        String yIntercept = df.format(Calc.getY_Intercept(xNum));
        
        /* Table D */
        String tableD_Head[] = { "R", "R^2", "Slope", "Y Intercept" };
        String tableD_data[][] = { { r, rSqrd, slope, yIntercept } };
        
        // Table
        JTable tableD = new JTable(tableD_data,tableD_Head);
        
        // ScrollPane
        JScrollPane scrollPaneD = new JScrollPane(tableD);
        scrollPaneD.setBounds(10, 280, 350, 40);
        
        GUI.win.add(scrollPaneD);
    }
    
    
    private void tableE(int xNum) {
        int num = Calc.getNum();
        List yArr = Calc.getYArray();
        List xArr = Calc.getXArray(xNum);
        List yFcast = Calc.getY_Forecast(xNum);
        List yStdErr = Calc.getY_StdErr(xNum);
        
        String x1, y1, yFut, yErr;
        
        /* Table E */
        String tableE_Head[] = { "X", "Y", "Forecasted Y", "Std. Err. of Estimate" };
        String tableE_data[][] = { };
        
        DefaultTableModel listTableModel = new DefaultTableModel(tableE_data, tableE_Head);
        
        for (int i = 0; i < num; i++) {
            x1 = df.format(xArr.get(i));
            y1 = df.format(yArr.get(i));
            yFut = df.format(yFcast.get(i));
            yErr = df.format(yStdErr.get(i));
            
            listTableModel.addRow( new Object[]{ x1, y1, yFut, yErr } );
        }
        
        int[] best = Calc.orderGraphCorrel();
        if (xIn == best[0]) {
            int compNum = Calc.getCompNum();
            List yComp = Calc.getYComp();
            List xComp = Calc.getXComp(best[0]);
            List yCompFcast = Calc.getCompForecast();
            List yCompStdErr = Calc.getCompStdErr();

            for (int i = 0; i < compNum; i++) {
                x1 = df.format(xComp.get(i));
                y1 = df.format(yComp.get(i));
                yFut = df.format(yCompFcast.get(i));
                yErr = df.format(yCompStdErr.get(i));

                listTableModel.addRow( new Object[]{ x1, y1, yFut, yErr } );
            }
        }
        
        // Table
        JTable tableE = new JTable(listTableModel);
        
        // ScrollPane
        JScrollPane scrollPaneE = new JScrollPane(tableE);
        scrollPaneE.setBounds(10, 50, 350, 210);
        
        GUI.win.add(scrollPaneE);
    }
    
    
    private void graph(List xArr) {
        /* Graph */
        Graphs graph = new Graphs(xArr, Calc.getYArray());
        graph.setPreferredSize(new Dimension(1000,275));
        
        JFrame frame = new JFrame();
        frame.add(graph);
        frame.pack();
        
        GUI.win.add(graph);
    }
    
    
    private String predYCheck() {
        try {
            xTextbox = Double.parseDouble(predict.getText());
            if (xTextbox < 0)
                return "Data entered is negative!";
        }
        catch (Exception e1) {
            return e1.getMessage();
        }
        
        return "predicting";
    }
    
    
    public static int getX_Input() { return xIn; }
    public static String getX_Name() { return xName; }
    public static String getNames(int x) { return choice[x]; }
    
    
    /* Creates button objects */
    private JButton menu = new JButton("Return to Menu");
    private JButton update = new JButton("Update Graph");
    private JButton compare = new JButton("Compare All Graphs");
    private JButton yPredict = new JButton("Predict Y");
    
    private static String[] choice = {"Bathrooms", "Area", "Size", "Garages", "Rooms", "Bedroom", "Age"};  // String array for combobox
    
    private JComboBox select = new JComboBox(choice);
    
    private List<Double> xInput = new ArrayList();
    
    private DecimalFormat df = new DecimalFormat("#.####");
    
    private static String type, xName;
    private static int xIn;
    
    private static double xTextbox;
    private static double slope;
    private static double yIntercept;
    
    private JLabel predLabel = new JLabel("Entering an X value");
    
    private JTextField predict = new JTextField();
}

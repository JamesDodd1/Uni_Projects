
package houseforecasting;

import GUI.DataInputs;
import java.util.ArrayList;
import java.util.List;


public class Calc extends LinkedLists {
    
    protected static LinkedLists lists;
    protected static LinkedLists compList = new LinkedLists();
    
    /* arrData retieves data input from textboxes */
    public static String arrData(String[] yArr, String[] x1Arr, String[] x2Arr, String[] x3Arr, String[] x4Arr, String[] x5Arr, String[] x6Arr, String[] x7Arr) {
        if (DataInputs.getNewData())
            lists = new LinkedLists();     // Create new linked list;
        else
            compList = new LinkedLists();
        
        double listLength = yArr.length;
        
        try {
            /* Checks if textboxes are empty */
            if (yArr[0].equals("") || x1Arr[0].equals("")  || x2Arr[0].equals("") || x3Arr[0].equals("") || x4Arr[0].equals("") || x5Arr[0].equals("") || 
                    x6Arr[0].equals("") || x7Arr[0].equals("")) {
                return "At least one of the textboxes are empty";
            }
            /* Checks all textboxes have the same number of variables */
            else if (listLength != x1Arr.length || listLength != x2Arr.length || listLength != x3Arr.length || listLength != x4Arr.length || 
                    listLength != x5Arr.length || listLength != x6Arr.length || listLength != x7Arr.length) {
                return "Not all eight inputs are the same length";
            }
            else {
                /* Creates arrays for each input */
                double[] yNum = new double[yArr.length];
                double[] x1Num = new double[x1Arr.length];
                double[] x2Num = new double[x2Arr.length];
                double[] x3Num = new double[x3Arr.length];
                double[] x4Num = new double[x4Arr.length];
                double[] x5Num = new double[x5Arr.length];
                double[] x6Num = new double[x6Arr.length];
                double[] x7Num = new double[x7Arr.length];

                try {
                    
                    /* Loops for each number entered */
                    for (int i = 0; i < yArr.length; i++) {
                        
                        /* Converts all data in each textboc to double type and stores in an array */
                        yNum[i] = Double.parseDouble(yArr[i].trim());
                        x1Num[i] = Double.parseDouble(x1Arr[i].trim());
                        x2Num[i] = Double.parseDouble(x2Arr[i].trim());
                        x3Num[i] = Double.parseDouble(x3Arr[i].trim());
                        x4Num[i] = Double.parseDouble(x4Arr[i].trim());
                        x5Num[i] = Double.parseDouble(x5Arr[i].trim());
                        x6Num[i] = Double.parseDouble(x6Arr[i].trim());
                        x7Num[i] = Double.parseDouble(x7Arr[i].trim());
                        
                        if (DataInputs.getNewData()) {
                            lists.addNode(yNum[i], x1Num[i], x2Num[i], x3Num[i], x4Num[i], x5Num[i], x6Num[i], x7Num[i]);   // Adds node with variables to list
                            dataLength = yArr.length;
                        }
                        else {
                            compList.addNode(yNum[i], x1Num[i], x2Num[i], x3Num[i], x4Num[i], x5Num[i], x6Num[i], x7Num[i]);    // Adds node with variables to compList
                            compLength = yArr.length;
                        }
                    }
                    
                    //LinkedLists.printList(lists);   // TEST
                    //System.out.println("DONE!");    // TEST
                } catch (Exception e1) {
                    //System.out.println("HELP!");    // TEST
                    //System.out.println(e1.getMessage());    // Prints error message
                    return e1.getMessage(); // Returns error message
                }
            }
        } catch (Exception e2) {
            System.out.println(e2.getMessage());    // Prints error message
            return e2.getMessage(); // Returns error message
        }
        
        Calc();
        return "Data has been added";   // Returns success message
    }
    
    
    private static void Calc() {
        if (DataInputs.getNewData()) {
            ResetCalc();


            Sum(lists.root);    // Calulates sum of each
            Mean();             // Calculates mean of each

            Syy(lists.root);  // Calculates Syy
            Sxx(lists.root);  // Calculates Sxx
            Sxy(lists.root);  // Calculates Sxy

            Variance();  // Call Variance method
            StandDev();  // Call StandDev method

            CorelCoeff();   // Call CorelCoeff method

            Slope();        // Call Slope method
            Y_Intercept();  // Call Y_Intercept method

            Y_Forecast(lists.root); // Call Y_Forecast method
            Y_StdErr(lists.root);   // Call Y_StdErr method

            setX1Array(lists.root); // Sets x1Arr list
            setX2Array(lists.root); // Sets x2Arr list
            setX3Array(lists.root); // Sets x3Arr list
            setX4Array(lists.root); // Sets x4Arr list
            setX5Array(lists.root); // Sets x5Arr list
            setX6Array(lists.root); // Sets x6Arr list
            setX7Array(lists.root); // Sets x7Arr list
            setYArray(lists.root);  // Sets yArr list

            /*
            // TESTING
            System.out.println("X Mean: " + xMean[0] + ", " + xMean[1] + ", " + xMean[2] + ", " + xMean[3] + ", " + xMean[4] + ", " + xMean[5] + ", " + xMean[6]);
            System.out.println("Y Mean: " + yMean + "\n");

            System.out.println("Sxx: " + sxx[0] + ", " + sxx[1] + ", " + sxx[2] + ", " + sxx[3] + ", " + sxx[4] + ", " + sxx[5] + ", " + sxx[6]);
            System.out.println("Syy: " + syy);
            System.out.println("Sxy: " + sxy[0] + ", " + sxy[1] + ", " + sxy[2] + ", " + sxy[3] + ", " + sxy[4] + ", " + sxy[5] + ", " + sxy[6] + "\n");

            System.out.println("X Variance: " + xVariance[0] + ", " + xVariance[1] + ", " + xVariance[2] + ", " + xVariance[3] + ", " + xVariance[4] + ", " + xVariance[5] + ", " + xVariance[6]);
            System.out.println("Y Variance: " + yVariance + "\n");

            System.out.println("X Standard Deviation: " + xStandDev[0] + ", " + xStandDev[1] + ", " + xStandDev[2] + ", " + xStandDev[3] + ", " + xStandDev[4] + ", " + xStandDev[5] + ", " + xStandDev[6]);
            System.out.println("Y Standard Deviation: " + yStandDev + "\n");

            System.out.println("r^2: " + rSqrd[0] + ", " + rSqrd[1] + ", " + rSqrd[2] + ", " + rSqrd[3] + ", " + rSqrd[4] + ", " + rSqrd[5] + ", " + rSqrd[6]);
            System.out.println("r: " + r[0] + ", " + r[1] + ", " + r[2] + ", " + r[3] + ", " + r[4] + ", " + r[5] + ", " + r[6] + "\n");

            System.out.println("Slope: " + b1[0] + ", " + b1[1] + ", " + b1[2] + ", " + b1[3] + ", " + b1[4] + ", " + b1[5] + ", " + b1[6]);
            System.out.println("Y Intercept: " + b0[0] + ", " + b0[1] + ", " + b0[2] + ", " + b0[3] + ", " + b0[4] + ", " + b0[5] + ", " + b0[6] + "\n");

            LinkedLists.printFcast(lists);
            */
        }
        else {
            ResetComp();    // Resets compare lists
            
            setX1Comp(compList.root);  // Sets x1Comp list
            setX2Comp(compList.root);  // Sets x2Comp list
            setX3Comp(compList.root);  // Sets x3Comp list
            setX4Comp(compList.root);  // Sets x4Comp list
            setX5Comp(compList.root);  // Sets x5Comp list
            setX6Comp(compList.root);  // Sets x6Comp list
            setX7Comp(compList.root);  // Sets x7Comp list
            setYComp(compList.root);   // Sets yComp list
            
            Y_CompForecast();
            Y_CompStdErr();
        }
    }
    
    
    public static void setX1Array(Nodes node) {	
        int i = 0;
        while (node != null) {
            x1Arr.add(node.getBathrooms());    // Adds to array list
            node = node.getRight();            // Next node
        }
    }
    
    public static void setX2Array(Nodes node) {	
        while (node != null) {
             x2Arr.add(node.getArea());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX3Array(Nodes node) {	
        int i = 0;
        while (node != null) {
             x3Arr.add(node.getSize());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX4Array(Nodes node) {	
        int i = 0;
        while (node != null) {
             x4Arr.add(node.getGarages());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX5Array(Nodes node) {	
        int i = 0;
        while (node != null) {
             x5Arr.add(node.getRooms());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX6Array(Nodes node) {	
        int i = 0;
        while (node != null) {
             x6Arr.add(node.getBedrooms());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX7Array(Nodes node) {	
        int i = 0;
        while (node != null) {
             x7Arr.add(node.getAge());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setYArray(Nodes node) {	
        int i = 0;
        while (node != null) {
             yArr.add(node.getPrice());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static List<Double> getXArray(int x) {
        List<Double> temp = new ArrayList();
        switch (x) {
            case 0:
                temp = getX1Array();
                break;
            case 1:
                temp = getX2Array();
                break;
            case 2:
                temp = getX3Array();
                break;
            case 3:
                temp = getX4Array();
                break;
            case 4: 
                temp = getX5Array();
                break;
            case 5: 
                temp = getX6Array();
                break;
            case 6:
                temp = getX7Array();
                break;
            default:
                break;
        }
        return temp;
    }
    public static List<Double> getX1Array() { return x1Arr; }
    public static List<Double> getX2Array() { return x2Arr; }
    public static List<Double> getX3Array() { return x3Arr; }
    public static List<Double> getX4Array() { return x4Arr; }
    public static List<Double> getX5Array() { return x5Arr; }
    public static List<Double> getX6Array() { return x6Arr; }
    public static List<Double> getX7Array() { return x7Arr; }
    public static List<Double> getYArray() { return yArr; }
    
    
    public static void setX1Comp(Nodes node) {	
        int i = 0;
        while (node != null) {
            x1Comp.add(node.getBathrooms());    // Adds to array list
            node = node.getRight();            // Next node
        }
    }
    
    public static void setX2Comp(Nodes node) {	
        while (node != null) {
             x2Comp.add(node.getArea());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX3Comp(Nodes node) {	
        int i = 0;
        while (node != null) {
             x3Comp.add(node.getSize());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX4Comp(Nodes node) {	
        int i = 0;
        while (node != null) {
             x4Comp.add(node.getGarages());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX5Comp(Nodes node) {	
        int i = 0;
        while (node != null) {
             x5Comp.add(node.getRooms());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX6Comp(Nodes node) {	
        int i = 0;
        while (node != null) {
             x6Comp.add(node.getBedrooms());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setX7Comp(Nodes node) {	
        int i = 0;
        while (node != null) {
             x7Comp.add(node.getAge());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static void setYComp(Nodes node) {	
        int i = 0;
        while (node != null) {
             yComp.add(node.getPrice());    // Adds to array list
             node = node.getRight();            // Next node
        }
    }
    
    public static List<Double> getXComp(int x) {
        List<Double> temp = new ArrayList();
        switch (x) {
            case 0:
                temp = getX1Comp();
                break;
            case 1:
                temp = getX2Comp();
                break;
            case 2:
                temp = getX3Comp();
                break;
            case 3:
                temp = getX4Comp();
                break;
            case 4: 
                temp = getX5Comp();
                break;
            case 5: 
                temp = getX6Comp();
                break;
            case 6:
                temp = getX7Comp();
                break;
            default:
                break;
        }
        return temp;
    }
    public static List<Double> getX1Comp() { return x1Comp; }
    public static List<Double> getX2Comp() { return x2Comp; }
    public static List<Double> getX3Comp() { return x3Comp; }
    public static List<Double> getX4Comp() { return x4Comp; }
    public static List<Double> getX5Comp() { return x5Comp; }
    public static List<Double> getX6Comp() { return x6Comp; }
    public static List<Double> getX7Comp() { return x7Comp; }
    public static List<Double> getYComp() { return yComp; }
    
    
    private static void ResetCalc() {
        sumY = 0;
        syy = 0;
        
        for (int i = 0; i < 7; i++) {
            sumX[i] = 0;
            sxx[i] = 0;
            sxy[i] = 0;
        }
        
        x1Arr.clear();
        x2Arr.clear();
        x3Arr.clear();
        x4Arr.clear();
        x5Arr.clear();
        x6Arr.clear();
        x7Arr.clear();
        yArr.clear();

        y1Forecast.clear();
        y2Forecast.clear();
        y3Forecast.clear();
        y4Forecast.clear();
        y5Forecast.clear();
        y6Forecast.clear();
        y7Forecast.clear();

        y1StdErr.clear();
        y2StdErr.clear();
        y3StdErr.clear();
        y4StdErr.clear();
        y5StdErr.clear();
        y6StdErr.clear();
        y7StdErr.clear();
    }
    
    
    private static void ResetComp() {
        x1Comp.clear();
        x2Comp.clear();
        x3Comp.clear();
        x4Comp.clear();
        x5Comp.clear();
        x6Comp.clear();
        x7Comp.clear();
        yComp.clear();
    }
    
    
    private static void Sum(Nodes node) {
        double y;
        double[] x = new double[7];
        
        /* Counts total of each */
        while (node != null) {
            /* Sets each variable */
            y = node.getPrice();
            x[0] = node.getBathrooms();
            x[1] = node.getArea();
            x[2] = node.getSize();
            x[3] = node.getGarages();
            x[4] = node.getRooms();
            x[5] = node.getBedrooms();
            x[6] = node.getAge();
            
            /* Calculate sum */
            sumY = sumY + y;
            sumYY = sumYY + (y * y);
            
            for (int i = 0; i < 7; i++) {
                sumX[i] = sumX[i] + x[i];
                sumXX[i] = sumXX[i] + (x[i] * x[i]);
                sumXY[i] = sumXY[i] + (x[i] * y);
            }
            
            node = node.getRight(); // Next node
        }
    }
    
    
    private static void Mean() {
        for (int i = 0; i < 7; i++) {
            xMean[i] = sumX[i] / dataLength;
        }
        
        yMean = sumY / dataLength;
    }
    
    
    private static void Syy(Nodes node) {
        double y = 0;
        
        syy = 0;    // Reset syy
        
        while (node != null) {
            // Calc Sxx for Price (y)
            y = (node.getPrice() - yMean) * (node.getPrice() - yMean);
            syy = syy + y;
            
            node = node.getRight(); // Move to next node
        }
    }
    
    
    private static void Sxx(Nodes node) {
        double x = 0;
        
        while (node != null) {
            for (int i = 0; i < 7; i++) {
                switch (i) {
                    // Calc Sxx for Bathrooms (x1)
                    case 0: 
                        x = (node.getBathrooms() - xMean[i]) * (node.getBathrooms() - xMean[i]);
                        sxx[i] = sxx[i] + x;
                        continue;
                        
                    // Calc Sxx for Ares (x2)
                    case 1: 
                        x = (node.getArea() - xMean[i]) * (node.getArea() - xMean[i]);
                        sxx[i] = sxx[i] + x;
                        continue;
                        
                    // Calc Sxx for Size (x3)
                    case 2: 
                        x = (node.getSize() - xMean[i]) * (node.getSize() - xMean[i]);
                        sxx[i] = sxx[i] + x;
                        continue;
                        
                    // Calc Sxx for Garages (x4)
                    case 3: 
                        x = (node.getGarages() - xMean[i]) * (node.getGarages() - xMean[i]);
                        sxx[i] = sxx[i] + x;
                        continue;
                        
                    // Calc Sxx for Rooms (x5)
                    case 4: 
                        x = (node.getRooms() - xMean[i]) * (node.getRooms() - xMean[i]);
                        sxx[i] = sxx[i] + x;
                        continue;
                        
                    // Calc Sxx for Bedrooms (x6)
                    case 5: 
                        x = (node.getBedrooms() - xMean[i]) * (node.getBedrooms() - xMean[i]);
                        sxx[i] = sxx[i] + x;
                        continue;
                        
                    // Calc Sxx for Age (x7)
                    case 6: 
                        x = (node.getAge() - xMean[i]) * (node.getAge() - xMean[i]);
                        sxx[i] = sxx[i] + x;
                        continue;
                }
            }
            node = node.getRight(); // Move to next node
        }
    }
    
    
    private static void Sxy(Nodes node) {
        double xy = 0;
        
        while (node != null) {
            for (int i = 0; i < 7; i++) {
                switch (i) {
                    // Calc Sxy for Bathrooms (x1)
                    case 0: 
                        xy = (node.getBathrooms() - xMean[i]) * (node.getPrice() - xMean[i]);
                        sxy[i] = sxy[i] + xy;
                        continue;
                        
                    // Calc Sxy for Ares (x2)
                    case 1: 
                        xy = (node.getArea() - xMean[i]) * (node.getPrice() - xMean[i]);
                        sxy[i] = sxy[i] + xy;
                        continue;
                        
                    // Calc Sxy for Size (x3)
                    case 2: 
                        xy = (node.getSize() - xMean[i]) * (node.getPrice() - xMean[i]);
                        sxy[i] = sxy[i] + xy;
                        continue;
                        
                    // Calc Sxy for Garages (x4)
                    case 3: 
                        xy = (node.getGarages() - xMean[i]) * (node.getPrice() - xMean[i]);
                        sxy[i] = sxy[i] + xy;
                        continue;
                        
                    // Calc Sxy for Rooms (x5)
                    case 4: 
                        xy = (node.getRooms() - xMean[i]) * (node.getPrice() - xMean[i]);
                        sxy[i] = sxy[i] + xy;
                        continue;
                        
                    // Calc Sxy for Bedrooms (x6)
                    case 5: 
                        xy = (node.getBedrooms() - xMean[i]) * (node.getPrice() - xMean[i]);
                        sxy[i] = sxy[i] + xy;
                        continue;
                        
                    // Calc Sxy for Age (x7)
                    case 6: 
                        xy = (node.getAge() - xMean[i]) * (node.getPrice() - xMean[i]);
                        sxy[i] = sxy[i] + xy;
                        continue;
                }
            }
            node = node.getRight(); // Move to next node
        }
    }
    
    
    private static void Variance() {
        for (int i = 0; i < 7; i++) {
            xVariance[i] = sxx[i] / dataLength;
        }
        
        yVariance = syy / dataLength;
    }
    
    
    private static void StandDev() {
        for (int i = 0; i < 7; i++) {
            xStandDev[i] = Math.sqrt(xVariance[i]);
        }
        
        yStandDev = Math.sqrt(yVariance);
    }
    
    
    private static void CorelCoeff() {
        for (int i = 0; i < 7; i++) {
            rSqrd[i] = (sxy[i] * sxy[i]) / (sxx[i] * syy);
            r[i] = Math.sqrt(rSqrd[i]);
        }
    }
    
    
    private static void Slope() {
        for (int i = 0; i < 7; i++) {
            b1[i] = sxy[i] / sxx[i];
        }
    }
    
    
    private static void Y_Intercept() {
        for (int i = 0; i < 7; i++) {
            b0[i] = yMean - (b1[i] * xMean[i]);
        }
    }
    
    
    private static void Y_Forecast(Nodes node) {
        while (node != null) { 
            y1Forecast.add((b1[0] * node.getBathrooms()) + b0[0]);
            y2Forecast.add((b1[1] * node.getArea()) + b0[1]);
            y3Forecast.add((b1[2] * node.getSize()) + b0[2]);
            y4Forecast.add((b1[3] * node.getGarages()) + b0[3]);
            y5Forecast.add((b1[4] * node.getRooms()) + b0[4]);
            y6Forecast.add((b1[5] * node.getBedrooms()) + b0[5]);
            y7Forecast.add((b1[6] * node.getAge()) + b0[6]);
            
            node = node.getRight(); // Move to next node
        }
    }
    
    
    private static void Y_StdErr(Nodes node) {
        double y;
        int i = 0;
        
        while (node != null) {
            y = node.getPrice();
            y1StdErr.add(y1Forecast.get(i) - y);
            y2StdErr.add(y2Forecast.get(i) - y);
            y3StdErr.add(y3Forecast.get(i) - y);
            y4StdErr.add(y4Forecast.get(i) - y);
            y5StdErr.add(y5Forecast.get(i) - y);
            y6StdErr.add(y6Forecast.get(i) - y);
            y7StdErr.add(y7Forecast.get(i) - y);
            
            i++;
            node = node.getRight(); // Move to next node
        }
    }
    
    
    public static int[] orderGraphCorrel() {
        double[] rSqrd_Copy = rSqrd.clone();
        int[] pos = {0,1,2,3,4,5,6};
        
        double temp;
        int temp2;
        
        /* Ordering correlating graph */
        for (int j = 1; j < 7; j++) {
            for (int i = 1; i < 7; i++) {
                if (rSqrd_Copy[i] > rSqrd_Copy[i-1]) {
                    temp = rSqrd_Copy[i];
                    rSqrd_Copy[i] = rSqrd_Copy[i-1];
                    rSqrd_Copy[i-1] = temp;
                    
                    temp2 = pos[i];
                    pos[i] = pos[i-1];
                    pos[i-1] = temp2;
                }
            }
        }
        
        return pos;
    }
    
    
    private static void Y_CompForecast() {
        int[] best = orderGraphCorrel();
        List<Double> xComp = getXComp(best[0]);
        
        for (int i = 0; i < xComp.size(); i++)
            yCompFcast.add((b1[best[0]] * xComp.get(i)) + b0[best[0]]);
    }
    
    
    private static void Y_CompStdErr() {
        int[] best = orderGraphCorrel();
        List<Double> xComp = getXComp(best[0]);
        
        for (int i = 0; i < xComp.size(); i++)
            yCompStdErr.add(yCompFcast.get(i) - yComp.get(i));
    }
    
    
    public static int getCompNum() { return compLength; }
    public static List getCompForecast() { return yCompFcast; }
    public static List getCompStdErr() { return yCompStdErr; }
    
    
    /* TABLE B */
    public static int getNum() { return dataLength; }
    public static double getY_Mean() { return yMean; }
    public static double getY_Variance() { return yVariance; }
    public static double getY_StandDev() { return yStandDev; }
    public static double getX_Mean(int x) { return xMean[x]; }
    public static double getX_Variance(int x) { return xVariance[x]; }
    public static double getX_StandDev(int x) { return xStandDev[x]; }
    
    
    /* TABLE C */
    public static double getSumY() { return sumY; }
    public static double getSumYY() { return sumYY; }
    public static double getSumX(int x) { return sumX[x]; }
    public static double getSumXX(int x) { return sumXX[x]; }
    public static double getSumXY(int x) { return sumXY[x]; }
    
    
    /* TABLE D */
    public static double getR(int x) { return r[x]; }
    public static double getR_Sqrd(int x) { return rSqrd[x]; }
    public static double getSlope(int x) { return b1[x]; }
    public static double getY_Intercept(int x) { return b0[x]; }
    
    
    /* TABLE E */
    public static List getY_Forecast(int y) { 
        List<Double> temp = new ArrayList();
        switch (y) {
            case 0:
                temp = getY1_Forecast();
                break;
            case 1:
                temp = getY2_Forecast();
                break;
            case 2:
                temp = getY3_Forecast();
                break;
            case 3:
                temp = getY4_Forecast();
                break;
            case 4: 
                temp = getY5_Forecast();
                break;
            case 5: 
                temp = getY6_Forecast();
                break;
            case 6:
                temp = getY7_Forecast();
                break;
            default:
                break;
        }
        return temp; 
    }
    public static List getY1_Forecast() { return y1Forecast; }
    public static List getY2_Forecast() { return y2Forecast; }
    public static List getY3_Forecast() { return y3Forecast; }
    public static List getY4_Forecast() { return y4Forecast; }
    public static List getY5_Forecast() { return y5Forecast; }
    public static List getY6_Forecast() { return y6Forecast; }
    public static List getY7_Forecast() { return y7Forecast; }
    
    public static List getY_StdErr(int y) { 
        List<Double> temp = new ArrayList();
        switch (y) {
            case 0:
                temp = getY1_StdErr();
                break;
            case 1:
                temp = getY2_StdErr();
                break;
            case 2:
                temp = getY3_StdErr();
                break;
            case 3:
                temp = getY4_StdErr();
                break;
            case 4: 
                temp = getY5_StdErr();
                break;
            case 5: 
                temp = getY6_StdErr();
                break;
            case 6:
                temp = getY7_StdErr();
                break;
            default:
                break;
        }
        return temp; 
    }
    public static List getY1_StdErr() { return y1StdErr; }
    public static List getY2_StdErr() { return y2StdErr; }
    public static List getY3_StdErr() { return y3StdErr; }
    public static List getY4_StdErr() { return y4StdErr; }
    public static List getY5_StdErr() { return y5StdErr; }
    public static List getY6_StdErr() { return y6StdErr; }
    public static List getY7_StdErr() { return y7StdErr; }
    
    
    /*
    TABLE A: Y | X | X - Mean X | Y - Mean Y | Sxx | Syy | Sxy  // Not needed
    
    TABLE B:                    | X | Y |
             n                  |   |   | 
             mean               |   |   |
             variance           |   |   |
             standard deviation |   |   |
    
    TABLE C: ∑X	  | 
             ∑X^2 | 
             ∑Y   | 
             ∑Y^2 | 
             ∑XY  | 
    
    TABLE D: R | R^2 | Slope | Y Intercept
    
    TABLE E: Forecasted Y | Std. Err. of Estimate
    
    
    TABLE A
    Sxx => Sum of all ( (x - Mean x) * (x - Mean x) )   DONE
    Syy => Sum of all ( (y - Mean y) * (y - Mean y) )   DONE
    Sxy => Sum of all ( (x - Mean x) * (y - Mean y) )   DONE
    
    TABLE B
    Mean => Sum of all x / total num x      DONE
    Variance => Sxx / num x                 DONE
    Standard Deviation => √(Sxx / num x)    DONE
    
    TABLE C
    ∑X   => Sum of all  DONE
    ∑X^2 => Sum of all  DONE
    ∑Y   => Sum of all  DONE
    ∑Y^2 => Sum of all  DONE 
    ∑XY  => Sum of all  DONE
    
    TABLE D
    R => √R^2                                   DONE
    R^2 => (Sxy * Sxy) / (Sxx * Syy)            DONE
    Slope => Sxy / Sxx                          DONE (b1)
    Y Intercept => Mean y - (Slope * Mean x)    DONE (b0)
    
    TABLE E
    Forecasted Y => (x * Slope) + Y Intercept   DONE
    Std. Err. of Estimate => Forecasted Y - Y   DONE
    */
    
    
    /* Declare array lists */
    private static List<Double> x1Arr = new ArrayList();
    private static List<Double> x2Arr = new ArrayList();
    private static List<Double> x3Arr = new ArrayList();
    private static List<Double> x4Arr = new ArrayList();
    private static List<Double> x5Arr = new ArrayList();
    private static List<Double> x6Arr = new ArrayList();
    private static List<Double> x7Arr = new ArrayList();
    private static List<Double> yArr = new ArrayList();
    
    private static List<Double> y1Forecast = new ArrayList();
    private static List<Double> y2Forecast = new ArrayList();
    private static List<Double> y3Forecast = new ArrayList();
    private static List<Double> y4Forecast = new ArrayList();
    private static List<Double> y5Forecast = new ArrayList();
    private static List<Double> y6Forecast = new ArrayList();
    private static List<Double> y7Forecast = new ArrayList();
    
    private static List<Double> y1StdErr = new ArrayList();
    private static List<Double> y2StdErr = new ArrayList();
    private static List<Double> y3StdErr = new ArrayList();
    private static List<Double> y4StdErr = new ArrayList();
    private static List<Double> y5StdErr = new ArrayList();
    private static List<Double> y6StdErr = new ArrayList();
    private static List<Double> y7StdErr = new ArrayList();
    
    private static List<Double> x1Comp = new ArrayList();
    private static List<Double> x2Comp = new ArrayList();
    private static List<Double> x3Comp = new ArrayList();
    private static List<Double> x4Comp = new ArrayList();
    private static List<Double> x5Comp = new ArrayList();
    private static List<Double> x6Comp = new ArrayList();
    private static List<Double> x7Comp = new ArrayList();
    private static List<Double> yComp = new ArrayList();
    
    private static List<Double> yCompFcast = new ArrayList();
    private static List<Double> yCompStdErr = new ArrayList();
    
    
    /* Declare all variables */
    private static int dataLength, compLength;
    
    private static double sumY, sumYY, yMean, syy, yVariance, yStandDev;
    
    private static double[] sumX = new double[7];
    private static double[] sumXX = new double[7];
    private static double[] sumXY = new double[7];
    private static double[] xMean = new double[7];
    private static double[] sxx = new double[7];
    private static double[] sxy = new double[7];
    private static double[] xVariance = new double[7];
    private static double[] xStandDev = new double[7];
    private static double[] r = new double[7];
    private static double[] rSqrd = new double[7];
    private static double[] b0 = new double[7];
    private static double[] b1 = new double[7];
    private static double[] fcast = new double[7];
    private static double[] stdErr = new double[7];
}

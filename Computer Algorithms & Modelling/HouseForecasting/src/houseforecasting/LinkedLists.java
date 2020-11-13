
package houseforecasting;

import java.util.Arrays;


public class LinkedLists {
    
    private boolean rootSet = false;
    protected Nodes root;

    public LinkedLists() {
        root = new Nodes(); // Creates root node
    }
    
    
    /* ==================== ADD NEW NODE METHOD ==================== */
    public void addNode(double y, double x1, double x2, double x3, double x4, double x5, double x6, double x7) {
        Nodes tail;
        tail = root;
        
        /* If root node not empty */
        if (rootSet == true) {
            while (tail.getRight() != null) {
                tail = tail.getRight();
            }
            tail.setRight( new Nodes(y, x1, x2, x3, x4, x5, x6, x7, null) );    // Adds a new node (with variables) to end of list
        }
        /* If root node empty */
        else {
            tail.setElements(y, x1, x2, x3, x4, x5, x6, x7);    // Adds a new node (with variables) to end of list
            rootSet = true;
        }
    }
    
    
    
    /* For Testing */
    private boolean isEmpty() {
        return root == null;
    }
    
    public static void printList(LinkedLists list) {
        Nodes temp;
        if(list.isEmpty())
            System.out.println("List is empty");
        else {
            temp = list.root;
            while (temp != null) {
               // bathrooms, area, size, garages, rooms, bedrooms, age
               System.out.print("y: " + temp.getPrice() + ", x1: " + temp.getBathrooms() + ", x2: " + temp.getArea() + ", x3: " + temp.getSize() + ", x4: " + 
                       temp.getGarages() + ", x5: " + temp.getRooms() + ", x6: " + temp.getBedrooms() + ", x7: " + temp.getAge() + "\n");
               temp = temp.getRight();
               
            }
            System.out.println();
        }
    }
    
    public static void printFcast(LinkedLists list) {
        Nodes temp;
        if(list.isEmpty())
            System.out.println("Forecast is empty");
        else {
            temp = list.root;
            while (temp != null) {
               // bathrooms, area, size, garages, rooms, bedrooms, age
               //System.out.print("Forecasted Y: " + Arrays.toString(temp.getYForecast()) + ", Stardard Error " + Arrays.toString(temp.getYStdErr()) + "\n");
               temp = temp.getRight();
               
            }
            System.out.println();
        }
    }
    
}

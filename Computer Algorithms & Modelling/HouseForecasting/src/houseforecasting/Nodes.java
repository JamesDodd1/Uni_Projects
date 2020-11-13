
package houseforecasting;

import static java.nio.file.Files.delete;
import javafx.scene.Node;
import static jdk.nashorn.internal.runtime.JSType.NULL;


public class Nodes {
    
  private Nodes right;
  private double price, bathrooms, area, size, garages, rooms, bedrooms, age;
  
  
  /* Creates empty node, which points to nothing */
  public Nodes() {
    this(0, 0, 0, 0, 0, 0, 0, 0, null);
  }
  
  /* Creates an overloading node which inputs the elements and the next node */
  public Nodes(double y, double x1, double x2, double x3, double x4, double x5, double x6, double x7, Nodes rightNode) {
    price = y;
    bathrooms = x1;
    area = x2;
    size = x3;
    garages = x4;
    rooms = x5;
    bedrooms = x6;
    age = x7;
    right = rightNode;
  }
  
  
  
  /* ==================== GET VARIABLE DATA ==================== */
  public double getPrice() { return price; }
  public double getBathrooms() { return bathrooms; }
  public double getArea() { return area; }
  public double getSize() { return size; }
  public double getGarages() { return garages; }
  public double getRooms() { return rooms; }
  public double getBedrooms() { return bedrooms; }
  public double getAge() { return age; }
  public Nodes getRight() { return right; }
  
  
  
  /* ==================== SET VARIABLE DATA ==================== */
  public void setElements(double newPrice, double newBathrooms, double newArea, double newSize, double newGarages, double newRooms, double newBedrooms, double newAge) {
      price = newPrice; 
      bathrooms = newBathrooms;
      area = newArea;
      size = newSize; 
      garages = newGarages; 
      rooms = newRooms; 
      bedrooms = newBedrooms; 
      age = newAge; 
  }
  public void setPrice(double newPrice) { price = newPrice; }
  public void setBathrooms(double newBathrooms) { bathrooms = newBathrooms; }
  public void setArea(double newArea) { area = newArea; }
  public void setSize(double newSize) { size = newSize; }
  public void setGarages(double newGarages) { garages = newGarages; }
  public void setRooms(double newRooms) { rooms = newRooms; }
  public void setBedrooms(double newBedrooms) { bedrooms = newBedrooms; }
  public void setAge(double newAge) { age = newAge; }
  public void setRight(Nodes newRight) { right = newRight; }
  
  
 /* ==================== CHECK NODE ==================== */
  public boolean hasRight() { return  right != null; }
    
}


package Events;

public class Event {
    
    /* Declare variables */
    private String type;  
    private String value; 

    
    /* Get/Set methods */
    public String getType() { return type; }
    public void setType(String type) { this.type = type; }

    public String getValue() { return value; }
    public void setValue(String value) { this.value = value; }
    
    
    @Override
    public String toString() { return "type:" + type + " value:" + value; }
}


package Events;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class EventList {
    
    /* Declare variables */
    HashMap<String, List<EventListener>> eventListeners;
    
    
    public EventList() {
        eventListeners = new HashMap<>();
    }
    
    
    public void addListener(String type, EventListener listener) {
        List<EventListener> dbl = eventListeners.get(type);
        
        if (dbl == null) // If no listeners for this type already registered
            dbl = new ArrayList<>(); // Create a new list
        
        dbl.add(listener); // Add the listener to the list
        
        eventListeners.put(type, dbl); // Update the map
    }
    
    
    public void removeListener(String type, EventListener listener) {
        List<EventListener> dbl = eventListeners.get(type);
        
        if (dbl != null) // If there are any listeners for the specified event type
            while (dbl.remove(listener)); // Remove listener looping in case more than one
    }
    
    
    public List<EventListener> getListeners(String type) {
        return eventListeners.get(type);
    }
}


package ScriptReader;

import Events.Event;
import Events.EventList;
import Events.EventListener;
import java.io.File;
import java.io.IOException;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;
import org.xml.sax.helpers.DefaultHandler;


public class EventGeneratorFromXML extends DefaultHandler {
    
    /* Declare variables */
    public final static String EVENT_TAG = "dashboard_event";

    public final static String TYPE_TAG = "type";
    public final static String VALUE_TAG = "value";
    public final static String DELAY_TAG = "delay";

    public final static int delayUnits = 100; // 0.1 seconds
    
    private Event currentEvent = null; // Current event being processed
    private String currentTag = "";    // Current tag being processed

    // List of listeners registered to receive dashboard events
    private final EventList Listeners;

    // The xml parser object
    private final XMLReader xmlReader;
    
    
    public EventGeneratorFromXML() throws Exception {
        Listeners = new EventList();

        // The following code configures and creates an object known as a SAXParser which is capable of
        // reading and interpreting an XML file.
        SAXParserFactory spf = SAXParserFactory.newInstance();
        spf.setNamespaceAware(true);
        SAXParser saxParser = spf.newSAXParser();
        xmlReader = saxParser.getXMLReader();
    }
    
    
    public void processScriptFile(String filename) throws IOException, SAXException {
        // Register the current object to receive callbacks when elements are encountered in the XML file
        xmlReader.setContentHandler(this);
        
        // Start the parsing process.  As the file is processed methods in the startElement(), endElement() and
        // characters() methods in the current object will be called to handle the content of the XML file.
        xmlReader.parse(convertToFileURL(filename));
    }
    
    
    @Override
    public void startElement(String namespaceURI,
            String localName,
            String qName,
            Attributes atts)
            throws SAXException {

        currentTag = localName;

        if (currentTag.equals(EVENT_TAG)) {
            currentEvent = new Event();
        }
    }
    
    
    @Override
    public void characters(char ch[], int start, int length)
            throws SAXException {
        // Get the characters into a String and lose any unwanted whitespace
        String val = new String(ch, start, length).trim();

        if (val.length() < 1) {  // Is no characters to process (was all whitespace) just return
            return;
        }

        // process the characters based on what type of tag we are currently dealing with.
        switch (currentTag) {
            case TYPE_TAG:
                currentEvent.setType(val);
                break;
            case VALUE_TAG:
                currentEvent.setValue(val);
                break;
            case DELAY_TAG:
                pause(Integer.parseInt(val));
                break;
        }
    }
    
    @Override
    public void endElement(String uri, String localName, String qName)
            throws SAXException {

        if (localName.equals(EVENT_TAG)) {
            // get all listeners
            List<EventListener> listeners = Listeners.getListeners(currentEvent.getType());
            if (listeners != null) {
                // loop through the listeners passing the event object to them - this is "firing" the event
                for (EventListener dbel : listeners) {
                    dbel.processEvent(this, currentEvent);
                }
            }
            currentEvent = null;
        }
        currentTag = "";
    }
    
    
    private void pause(int delay) {
        try {
            Thread.sleep(delay * delayUnits);
        } catch (InterruptedException ex) {
            Logger.getLogger(EventGeneratorFromXML.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    
    public void registerEventListener(String type, EventListener dbel) {
        Listeners.addListener(type, dbel);
    }
    
    
    public void removeEventListener(String type, EventListener dbel) {
        Listeners.removeListener(type, dbel);
    }
    
    private static String convertToFileURL(String filename) {
        String path = new File(filename).getAbsolutePath();
        if (File.separatorChar != '/') {
            path = path.replace(File.separatorChar, '/');
        }

        if (!path.startsWith("/")) {
            path = "/" + path;
        }
        return "file:" + path;
    }
    
    private static void usage() {
        System.err.println("Usage:  DashboardEventGeneratorFromXML <file.xml>");
        System.err.println("       -usage or -help = this message");
        System.exit(1);
    }
    
    
    public static void main(String[] args) throws Exception {
        String filename = null;

        // get the filename if persent
        for (int i = 0; i < args.length; i++) {
            filename = args[i];
            if (i != args.length - 1) {
                usage();
            }
        }

        if (filename == null) {
            usage();
        }
        
        // Create an instance of DashboardEventGeneratorFromXML and test it
        EventGeneratorFromXML me = new EventGeneratorFromXML();
        EventListener dbel = new EventListener() {
            @Override
            public void processEvent(Object originator, Event dbe) {
                System.out.println("***** " + dbe);
            }
        };
        me.registerEventListener("speed", dbel);
        me.processScriptFile(filename);
        me.removeEventListener("speed", dbel);
        me.processScriptFile(filename);
    }
}

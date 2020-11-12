
package SingletonPattern;

import Dashboard.BarPanel;
import Dashboard.TrafficPanel;
import Events.Event;
import Events.EventListener;
import static DialFactoryPattern.CreateDial.createDial;
import ScriptReader.EventGeneratorFromXML;
import Threads.FuelThread;
import Threads.DialThread;
import Main.TrainDashboardMain;
import java.awt.FlowLayout;
import java.awt.Point;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.WindowConstants;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import DialFactoryPattern.Dial;
import static DigitalFactoryPattern.CreateDigital.createDigital;
import DigitalFactoryPattern.Digital;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;


public class Singleton extends JFrame {
    
    /* Declare variables */
    private static Singleton instance = null;
    
    public static final String XML_SCRIPT = "dashboard_script.xml";
    
    // Control panel fields 
    private JTextField txtFuelValueInput;
    private JTextField txtSpeedValueInput;
    private JTextField txtTempValueInput;
    private JTextField txtDoorsValueInput;
    private JButton btnScript;
    
    
    // Dashboard objects
    private BarPanel fuelBar;
    
    private Digital fuelDigital;
    private Digital speedDigital;
    private Digital tempDigital;
    
    private Dial speedDial;
    private Dial tempDial;
    
    private TrafficPanel doorsTraffic;
    
    
    // Threads
    private FuelThread fuelThread;
    private DialThread speedThread;
    private DialThread tempThread;
    
    
    public static synchronized Singleton getInstance() {
        if (instance == null) {
            instance = new Singleton();
        }
        return instance;
    }
    
    
    private Singleton() {
        CreateUserControls(); // Creates user controls frame
        CreateDashboard();    // Creates dashboard fram
        
        PowerOn(); // Sets dashboard panels
    }
    
    
    /* Creates user controls frame */
    private void CreateUserControls() {
        // Set up the frame for the user controls
        setTitle("User Controls");
        setLayout(new FlowLayout());
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        
        JPanel userControls = new JPanel();
        
        // Fuel input
        userControls.add(new JLabel("Fuel Value:"));
        txtFuelValueInput = new JTextField("100", 3);
        userControls.add(txtFuelValueInput);
        DocumentListener petrolListener = new FuelValueListener();
        txtFuelValueInput.getDocument().addDocumentListener(petrolListener);
        
        
        // Speed input
        userControls.add(new JLabel("Speed Value:"));
        txtSpeedValueInput = new JTextField("0", 3);
        userControls.add(txtSpeedValueInput);
        DocumentListener speedListener = new SpeedValueListener();
        txtSpeedValueInput.getDocument().addDocumentListener(speedListener);
        
        
        // Temperature input
        userControls.add(new JLabel("Temperature Value:"));
        txtTempValueInput = new JTextField("30", 3);
        userControls.add(txtTempValueInput);
        DocumentListener temperatureListener = new TempValueListener();
        txtTempValueInput.getDocument().addDocumentListener(temperatureListener);
        
        
        // Door state input
        userControls.add(new JLabel("Doors Open Value:"));
        txtDoorsValueInput = new JTextField("Closed", 4);
        userControls.add(txtDoorsValueInput);
        DocumentListener doorListener = new DoorsValueListener();
        txtDoorsValueInput.getDocument().addDocumentListener(doorListener);
        
        
        // XML button
        btnScript = new JButton("Run XML Script");
        btnScript.addActionListener(new ActionListener() { // When button clicked
            
            @Override
            public void actionPerformed(ActionEvent e) {
                new Thread() {
                    public void run() {
                        runXMLScript(); // Reads XML script
                    }
                }.start();
            }
        });
        
        userControls.add(btnScript);
        add(userControls);
        pack();
        
        
        setLocationRelativeTo(null); // Display in centre of screen
        this.setVisible(true);
    }
    
    
    /* Creates dashboard fram */
    private void CreateDashboard() {
        // Sets up the dashboard frame        
        JFrame dashboard = new JFrame("Train Dashboard");
        dashboard.setDefaultCloseOperation(WindowConstants.HIDE_ON_CLOSE);
        dashboard.setLayout(new GridBagLayout());
        
        GridBagConstraints gbc = new GridBagConstraints();
        
        
        // Adds the petrol bar
        fuelBar = new BarPanel();
        fuelBar.setTitle("FUEL");
        gbc.gridheight = 2;
        gbc.gridx = 0;
        gbc.gridy = 0;
        dashboard.add(fuelBar, gbc);
        
        
        // Adds the fuel digital display
        fuelDigital = createDigital("Fuel");
        gbc.gridheight = 1;
        gbc.gridx = 1;
        gbc.gridy = 0;
        dashboard.add(fuelDigital.getDigital(), gbc);
        
        
        // Add the door state traffic light
        doorsTraffic = new TrafficPanel();
        doorsTraffic.setLabel("DOORS STATE");
        gbc.gridx = 1;
        gbc.gridy = 1;
        dashboard.add(doorsTraffic, gbc);
        
        
        // Adds the speed digital display
        speedDigital = createDigital("Speed");
        gbc.gridx = 2;
        gbc.gridy = 0;
        dashboard.add(speedDigital.getDigital(), gbc);
        
        
        // Adds the speed dial
        speedDial = createDial("Speed");
        gbc.gridx = 2;
        gbc.gridy = 1;
        dashboard.add(speedDial.getDial(), gbc);
        
        
        // Adds the temperature digital display
        tempDigital = createDigital("Temp");
        gbc.gridx = 3;
        gbc.gridy = 0;
        dashboard.add(tempDigital.getDigital(), gbc);
        
        
        // Adds the temperature dial
        tempDial = createDial("Temp");
        gbc.gridx = 3;
        gbc.gridy = 1;
        dashboard.add(tempDial.getDial(), gbc);
        
        
        dashboard.pack();
        
        
        // Centres the dashboard frame above the control frame
        Point topLeft = this.getLocationOnScreen(); // Top left of control frame 
        
        int hControl = this.getHeight();   // Height of user controls frame 
        int wControl = this.getWidth();    // Width of user controls frame 
        int hDash = dashboard.getHeight(); // Height of dashboard frame 
        int wDash = dashboard.getWidth();  // Width of dashboard frame 
        
        
        // Calculates where the top left of the dashboard goes to centre it over the control frame
        Point p2 = new Point((int) topLeft.getX() - (wDash - wControl) / 2, (int) topLeft.getY() - (hDash + hControl));
        dashboard.setLocation(p2);
        dashboard.setVisible(true);
    }
    
    
    /* Sets starting values on dashboard */
    private void PowerOn() {
        fuelThread = new FuelThread(fuelBar, fuelDigital, 100);
        fuelThread.start();
        
        tempThread = new DialThread(tempDial, tempDigital, 30);
        tempThread.start();
    }
    
    
    /* When XML script run */
    private void runXMLScript() {
        try {
            EventGeneratorFromXML dbegXML = new EventGeneratorFromXML();
            
            
            // Read fuel from XML script
            EventListener dbelFuel = new EventListener() {
                @Override
                public void processEvent(Object originator, Event dbe) {
                    
                    // Stop any threads currently running
                    try {
                        if (fuelThread.isAlive() || fuelThread != null)
                            fuelThread.interrupt();
                    }
                    catch (Exception ea) {  }
                    
                    int value = Integer.parseInt(dbe.getValue()); // Set value from XML
                    
                    // Run thread to set new value
                    fuelThread = new FuelThread(fuelBar, fuelDigital, value);
                    fuelThread.start();
                }
            };
            dbegXML.registerEventListener("fuel", dbelFuel);
            
            
            // Read speed from XML script
            EventListener dbelSpeed = new EventListener() {
                @Override
                public void processEvent(Object originator, Event dbe) { 
                    
                    // Stop any threads currently running
                    try {
                        if (speedThread.isAlive() || speedThread != null)
                            speedThread.interrupt();
                    }
                    catch (Exception ea) {  }

                    int value = Integer.parseInt(dbe.getValue()); // Set value from XML
                    
                    // Run thread to set new value
                    speedThread = new DialThread(speedDial, speedDigital, value);
                    speedThread.start();
                }
            };
            dbegXML.registerEventListener("speed", dbelSpeed);
            
            
            // Read temperature from XML script
            EventListener dbelTemp = new EventListener() {
                @Override
                public void processEvent(Object originator, Event dbe) { 
                    
                    // Stop any threads currently running
                    try {
                        if (tempThread.isAlive() || tempThread != null)
                            tempThread.interrupt();
                    }
                    catch (Exception ea) {  }

                    int value = Integer.parseInt(dbe.getValue()); // Set value from XML
                    
                    // Run thread to set new value
                    tempThread = new DialThread(tempDial, tempDigital, value);
                    tempThread.start();
                }
            };
            dbegXML.registerEventListener("temp", dbelTemp);
            
            
            // Read door state from XML script
            EventListener dbelDoors = new EventListener() {
                @Override
                public void processEvent(Object originator, Event dbe) {
                    boolean doors = Boolean.parseBoolean(dbe.getValue()); // Set value from XML
                    doorsTraffic.setValue(doors); // Set new value
                }
            };
            dbegXML.registerEventListener("doors", dbelDoors);
            
            
            // Process the XML script 
            dbegXML.processScriptFile(XML_SCRIPT);

        } catch (Exception ex) {
            Logger.getLogger(TrainDashboardMain.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    
    /* Sets dashboard fuel */
    public void setFuel() {
        try {
            // Stop any threads currently running
            try {
                if (fuelThread.isAlive() || fuelThread != null)
                    fuelThread.interrupt();
            }
            catch (Exception ea) {  }
            
            int value = Integer.parseInt(txtFuelValueInput.getText().trim()); // Set value from textbox
            
            // Run thread to set new value
            fuelThread = new FuelThread(fuelBar, fuelDigital, value);
            fuelThread.start();
        } 
        catch (Exception e) {  }
    }
    
    
    /* Sets dashboard speed */
    public void setSpeed() {
        try {
            // Stop any threads currently running
            try {
                if (speedThread.isAlive() || speedThread != null)
                    speedThread.interrupt();
            }
            catch (Exception ea) {  }
            
            int value = Integer.parseInt(txtSpeedValueInput.getText().trim()); // Set value from textbox
            
            // Run thread to set new value
            speedThread = new DialThread(speedDial, speedDigital, value);
            speedThread.start();
        } catch (Exception e) {  }
    }
    
    
    /* Sets dashboard temperature */
    public void setTemp() {
        try {
            // Stop any threads currently running
            try {
                if (tempThread.isAlive() || tempThread != null)
                    tempThread.interrupt();
            }
            catch (Exception ea) {  }
            
            int value = Integer.parseInt(txtTempValueInput.getText().trim()); // Set value from textbox
            
            // Run thread to set new value
            tempThread = new DialThread(tempDial, tempDigital, value);
            tempThread.start();
        } 
        catch (Exception e) {  }
    }
    
    
    /* Sets dashboard door traffic light */
    public void setDoorsState() {
        try {
            String doorInput = txtDoorsValueInput.getText().trim().toLowerCase(); // Set value from textbox
            
            // Set new value
            if (doorInput.equals("open") || doorInput.equals("true")) 
                doorsTraffic.setValue(true);
            else
                doorsTraffic.setValue(false);
        } 
        catch (Exception e) {  }
    }
    
    
    /* Checks for changes in fuel value */
    private class FuelValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setFuel();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setFuel();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }
    
    
    /* Checks for changes in speed value */
    private class SpeedValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setSpeed();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setSpeed();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }
    
    
    /* Checks for changes in temperature value */
    private class TempValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setTemp();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setTemp();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }
    
    
    /* Checks for changes in door state value */
    private class DoorsValueListener implements DocumentListener {

        @Override
        public void insertUpdate(DocumentEvent event) {
            setDoorsState();
        }

        @Override
        public void removeUpdate(DocumentEvent event) {
            setDoorsState();
        }

        @Override
        public void changedUpdate(DocumentEvent event) {
        }
    }
}


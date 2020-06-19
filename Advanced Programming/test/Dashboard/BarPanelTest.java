
package Dashboard;

import org.junit.After;
import org.junit.AfterClass;
import static org.junit.Assert.assertEquals;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;


public class BarPanelTest {
    
    /* Declare variable */
    private BarPanel instance;
    
    
    public BarPanelTest() {
        
    }
    
    @BeforeClass
    public static void setUpClass() {
        
    }
    
    @AfterClass
    public static void tearDownClass() {
        
    }
    
    @Before
    public void setUp() {
        
    }
    
    @After
    public void tearDown() {
        
    }
    
    
    /* Testing */
    @Test
    public void testGetValue1() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue(0);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue2() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue(50);
        int expResult = 50;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue3() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue(100);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue4() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue(-1);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue5() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue(101);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue6() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue(-1000000000);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue7() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue(1000000000);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue8() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue(' ');
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue9() {
        System.out.println("getValue");
        
        instance = new BarPanel();
        instance.setValue('x');
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetMaxValue() {
        System.out.println("getMaxValue");
        
        instance = new BarPanel();
        double expResult = 100;
        double result = instance.getMaxValue();
        
        assertEquals(expResult, result, 0.0);
    }
    
    
    @Test
    public void testGetMinValue() {
        System.out.println("getMinValue");
        
        instance = new BarPanel();
        double expResult = 0;
        double result = instance.getMinValue();
        
        assertEquals(expResult, result, 0.0);
    }
}

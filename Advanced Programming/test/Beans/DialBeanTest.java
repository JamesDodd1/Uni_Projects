
package Beans;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;


public class DialBeanTest {
    
    /* Declare variable */
    private DialBean instance;
    
    
    public DialBeanTest() {
        
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
        
        instance = new DialBean(100);
        instance.setValue(0);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue2() {
        System.out.println("getValue");
        
        instance = new DialBean(100);
        instance.setValue(50);
        int expResult = 50;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue3() {
        System.out.println("getValue");
        
        instance = new DialBean(100);
        instance.setValue(100);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue4() {
        System.out.println("getValue");
        
        instance = new DialBean(100);
        instance.setValue(-1);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue5() {
        System.out.println("getValue");
        
        instance = new DialBean(100);
        instance.setValue(101);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue6() {
        System.out.println("getValue");
        
        instance = new DialBean(100);
        instance.setValue(-1000000000);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue7() {
        System.out.println("getValue");
        
        instance = new DialBean(100);
        instance.setValue(1000000000);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue8() {
        System.out.println("getValue");
        
        instance = new DialBean(100);
        instance.setValue(' ');
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue9() {
        System.out.println("getValue");
        
        instance = new DialBean(100);
        instance.setValue('x');
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }

    
    @Test
    public void testGetValue10() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue(0);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue11() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue(50);
        int expResult = 50;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue12() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue(100);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue13() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue(-1);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue14() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue(101);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue15() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue(-1000000000);
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue16() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue(1000000000);
        int expResult = 100;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue17() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue(' ');
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetValue18() {
        System.out.println("getValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        instance.setValue('x');
        int expResult = 0;
        int result = instance.getValue();
        
        assertEquals(expResult, result);
    }
    
    
    @Test
    public void testGetMaxValue1() {
        System.out.println("getMaxValue");
        
        instance = new DialBean(100);
        double expResult = 100;
        double result = instance.getMaxValue();
        
        assertEquals(expResult, result, 0.0);
    }
    
    
    @Test
    public void testGetMaxValue2() {
        System.out.println("getMaxValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        double expResult = 100;
        double result = instance.getMaxValue();
        
        assertEquals(expResult, result, 0.0);
    }
    
    
    @Test
    public void testGetMinValue1() {
        System.out.println("getMinValue");
        
        instance = new DialBean(100);
        int expResult = 0;
        double result = instance.getMinValue();
        
        assertEquals(expResult, result, 0);
    }
    
    
    @Test
    public void testGetMinValue2() {
        System.out.println("getMinValue");
        
        instance = new DialBean(0, 0, 0, 100, 0);
        int expResult = 0;
        double result = instance.getMinValue();
        
        assertEquals(expResult, result, 0);
    }
}
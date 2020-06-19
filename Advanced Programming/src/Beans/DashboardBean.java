
package Beans;

import java.awt.Graphics2D;


public interface DashboardBean {
    void drawObject(Graphics2D g2);
    int getMaxValue();
    int getMinValue();
    int getValue();
    void setValue(int value);
}

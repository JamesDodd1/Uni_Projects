
package DigitalFactoryPattern;

import Dashboard.DigitalPanel;


public interface Digital {
    DigitalPanel getDigital();
    int getMaxValue();
    int getMinValue();
    int getValue();
    void setValue(int value);
    void setTitle(String title);
}

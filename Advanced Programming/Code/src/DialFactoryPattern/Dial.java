
package DialFactoryPattern;

import Dashboard.DialPanel;


public interface Dial {
    DialPanel getDial();
    int getMaxValue();
    int getMinValue();
    int getValue();
    void setValue(int value);
    void setTitle(String title);
}


package Dashboard;


public interface DashboardPanel {
    int getMaxValue();
    int getMinValue();
    int getValue();
    void setValue(int value);
    void setTitle(String title);
}

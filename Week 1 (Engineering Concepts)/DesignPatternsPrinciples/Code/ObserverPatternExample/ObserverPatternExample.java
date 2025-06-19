// ObserverPatternExample.java
import java.util.*;

interface Stock {
    void add(Observer o);
    void remove(Observer o);
    void alert();
}

class StockMarket implements Stock {
    private List<Observer> obs = new ArrayList<>();
    private double price;
    
    public void add(Observer o) { obs.add(o); }
    public void remove(Observer o) { obs.remove(o); }
    public void alert() { for (Observer o : obs) o.update(price); }
    
    void setPrice(double p) { 
        this.price = p;
        alert();
    }
}

interface Observer {
    void update(double price);
}

class PhoneApp implements Observer {
    public void update(double p) {
        System.out.println("Phone: Price now $" + p);
    }
}

class ObserverPatternExample {
    public static void main(String[] args) {
        StockMarket nse = new StockMarket();
        nse.add(new PhoneApp());
        nse.setPrice(150.5);
    }
}

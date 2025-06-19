// Payment processor interface (target)
interface PayProcessor {
    void pay(double amount);
}

// Existing PayPal class (adaptee)
class PayPal {
    void sendPayment(double amount) {
        System.out.println("Paid $" + amount + " via PayPal.");
    }
}

// Existing Stripe class (adaptee)
class Stripe {
    void chargeCard(double amount) {
        System.out.println("Charged $" + amount + " via Stripe.");
    }
}

// Adapter for PayPal
class PayPalAdapter implements PayProcessor {
    private PayPal gateway;

    PayPalAdapter(PayPal gateway) {
        this.gateway = gateway;
    }

    public void pay(double amount) {
        gateway.sendPayment(amount);
    }
}

// Adapter for Stripe
class StripeAdapter implements PayProcessor {
    private Stripe gateway;

    StripeAdapter(Stripe gateway) {
        this.gateway = gateway;
    }

    public void pay(double amount) {
        gateway.chargeCard(amount);
    }
}

// Test class
public class AdapterPatternExample {
    public static void main(String[] args) {
        // Create payment gateways
        PayProcessor paypal = new PayPalAdapter(new PayPal());
        PayProcessor stripe = new StripeAdapter(new Stripe());

        // Process payments
        paypal.pay(50.0);
        stripe.pay(75.5);
    }
}


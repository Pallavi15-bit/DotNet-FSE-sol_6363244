interface PayMethod {
    void pay(int amt);
}

class CreditCard implements PayMethod {
    public void pay(int a) {
        System.out.println("Paid $" + a + " via credit card");
    }
}

class PayContext {
    private PayMethod method;
    void setMethod(PayMethod m) { this.method = m; }
    void execute(int a) { method.pay(a); }
}

class StrategyPatternExample {
    public static void main(String[] args) {
        PayContext ctx = new PayContext();
        ctx.setMethod(new CreditCard());
        ctx.execute(100);
    }
}

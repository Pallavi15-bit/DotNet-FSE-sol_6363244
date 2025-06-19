interface Notifier {
    void send();
}

class EmailNotifier implements Notifier {
    public void send() {
        System.out.println("Sending email");
    }
}

abstract class NotifierDecorator implements Notifier {
    protected Notifier wrappee;
    NotifierDecorator(Notifier n) { this.wrappee = n; }
    public void send() { wrappee.send(); }
}

class SMSDecorator extends NotifierDecorator {
    SMSDecorator(Notifier n) { super(n); }
    public void send() {
        super.send();
        System.out.println("Sending SMS");
    }
}

class DecoratorPatternExample {
    public static void main(String[] args) {
        Notifier combo = new SMSDecorator(new EmailNotifier());
        combo.send();
    }
}


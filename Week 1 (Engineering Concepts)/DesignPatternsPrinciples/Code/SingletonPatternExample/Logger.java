public class Logger {

    
    private static final Logger instance = new Logger();

   
    private Logger() {
        System.out.println("Logger instance created.");
    }

   
    public static Logger getInstance() {
        return instance;
    }

   
    public void log(String message) {
        System.out.println("[LOG] " + message);
    }

   
    public static void main(String[] args) {
        
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();

        
        System.out.println("Is logger1 the same as logger2? " + (logger1 == logger2));

        
        logger1.log("This is a test message from logger1.");
        logger2.log("Another test message from logger2.");
    }
}

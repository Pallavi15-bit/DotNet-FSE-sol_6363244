interface Image {
    void display();
}

class RealImage implements Image {
    private String file;
    RealImage(String f) { load(f); }
    private void load(String f) { 
        System.out.println("Loading " + f);
        this.file = f;
    }
    public void display() { System.out.println("Showing " + file); }
}

class ProxyImage implements Image {
    private RealImage img;
    private String file;
    ProxyImage(String f) { this.file = f; }
    public void display() {
        if (img == null) img = new RealImage(file);
        img.display();
    }
}

class ProxyPatternExample {
    public static void main(String[] args) {
        Image img = new ProxyImage("cat.jpg");
        img.display();
        img.display();
    }
}


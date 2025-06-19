interface Cmd {
    void run();
}

class Light {
    void on() { System.out.println("Light on"); }
}

class LightOnCmd implements Cmd {
    private Light bulb;
    LightOnCmd(Light l) { this.bulb = l; }
    public void run() { bulb.on(); }
}

class Remote {
    private Cmd cmd;
    void setCmd(Cmd c) { this.cmd = c; }
    void press() { cmd.run(); }
}

class CommandPatternExample {
    public static void main(String[] args) {
        Remote control = new Remote();
        control.setCmd(new LightOnCmd(new Light()));
        control.press();
    }
}

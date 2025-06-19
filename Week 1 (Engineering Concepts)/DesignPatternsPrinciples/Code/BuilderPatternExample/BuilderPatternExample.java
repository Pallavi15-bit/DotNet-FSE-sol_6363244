class Computer {
    private String cpu;
    private String ram;
    private String disk;
    private boolean gpu;
    private boolean bt;

   
    private Computer(Builder builder) {
        this.cpu = builder.cpu;
        this.ram = builder.ram;
        this.disk = builder.disk;
        this.gpu = builder.gpu;
        this.bt = builder.bt;
    }

    
    public String getCpu() { return cpu; }
    public String getRam() { return ram; }
    public String getDisk() { return disk; }
    public boolean hasGpu() { return gpu; }
    public boolean hasBt() { return bt; }

    
    public static class Builder {
        // Required parts: cpu, ram, disk
        private String cpu;
        private String ram;
        private String disk;

        // Optional parts: gpu and bluetooth
        private boolean gpu = false;
        private boolean bt = false;

        // Builder constructor needs the basics
        public Builder(String cpu, String ram, String disk) {
            this.cpu = cpu;
            this.ram = ram;
            this.disk = disk;
        }

        // Set optional gpu
        public Builder withGpu(boolean gpu) {
            this.gpu = gpu;
            return this;
        }

        // Set optional bluetooth
        public Builder withBt(boolean bt) {
            this.bt = bt;
            return this;
        }

        // Build the computer
        public Computer build() {
            return new Computer(this);
        }
    }
}


public class BuilderPatternExample {
    public static void main(String[] args) {
      
        Computer basic = new Computer.Builder("Intel i5", "8GB", "256GB SSD").build();

        Computer gaming = new Computer.Builder("Intel i9", "32GB", "1TB SSD")
            .withGpu(true)
            .withBt(true)
            .build();

        // Show what built
        System.out.println("Basic Computer:");
        System.out.println("- CPU: " + basic.getCpu());
        System.out.println("- RAM: " + basic.getRam());
        System.out.println("- Disk: " + basic.getDisk());
        System.out.println("- GPU: " + basic.hasGpu());
        System.out.println("- Bluetooth: " + basic.hasBt());

        System.out.println("\nGaming Computer:");
        System.out.println("- CPU: " + gaming.getCpu());
        System.out.println("- RAM: " + gaming.getRam());
        System.out.println("- Disk: " + gaming.getDisk());
        System.out.println("- GPU: " + gaming.hasGpu());
        System.out.println("- Bluetooth: " + gaming.hasBt());
    }
}

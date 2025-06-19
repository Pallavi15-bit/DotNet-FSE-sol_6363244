class Student {
    private String name;
    void setName(String n) { name = n; }
    String getName() { return name; }
}

class StudentView {
    void show(String name) {
        System.out.println("Student: " + name);
    }
}

class StudentController {
    private Student model;
    private StudentView view;
    
    StudentController(Student s, StudentView v) {
        this.model = s;
        this.view = v;
    }
    
    void updateName(String n) {
        model.setName(n);
        view.show(model.getName());
    }
}

class MVCPatternExample {
    public static void main(String[] args) {
        Student s = new Student();
        StudentView v = new StudentView();
        StudentController c = new StudentController(s, v);
        c.updateName("Alice");
    }
}

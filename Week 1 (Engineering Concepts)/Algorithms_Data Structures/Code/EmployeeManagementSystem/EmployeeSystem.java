public class EmployeeSystem {
    static class Employee {
        int employeeId;
        String name;
        String position;
        double salary;

        public Employee(int employeeId, String name, String position, double salary) {
            this.employeeId = employeeId;
            this.name = name;
            this.position = position;
            this.salary = salary;
        }

        public String toString() {
            return employeeId + " | " + name + " | " + position + " | Rs." + salary;
        }
    }

    static class EmployeeManager {
        Employee[] employees;
        int size;

        public EmployeeManager(int capacity) {
            employees = new Employee[capacity];
            size = 0;
        }

        public void add(Employee e) {
            if (size < employees.length) employees[size++] = e;
        }

        public Employee search(int id) {
            for (int i = 0; i < size; i++) {
                if (employees[i].employeeId == id) return employees[i];
            }
            return null;
        }

        public void traverse() {
            for (int i = 0; i < size; i++) {
                System.out.println(employees[i]);
            }
        }

        public void delete(int id) {
            for (int i = 0; i < size; i++) {
                if (employees[i].employeeId == id) {
                    for (int j = i; j < size - 1; j++) {
                        employees[j] = employees[j + 1];
                    }
                    size--;
                    break;
                }
            }
        }
    }

    public static void main(String[] args) {
        EmployeeManager manager = new EmployeeManager(10);

        manager.add(new Employee(1, "Aditi", "Developer", 60000));
        manager.add(new Employee(2, "Ravi", "Manager", 80000));
        manager.add(new Employee(3, "Meena", "Tester", 50000));

        System.out.println("All Employees:");
        manager.traverse();

        System.out.println("\nSearching for Employee with ID 2:");
        System.out.println(manager.search(2));

        manager.delete(2);
        System.out.println("\nAfter Deleting ID 2:");
        manager.traverse();
    }
}

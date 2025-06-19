public class TaskMS {
    static class Task {
        int taskId;
        String taskName;
        String status;
        Task next;

        public Task(int taskId, String taskName, String status) {
            this.taskId = taskId;
            this.taskName = taskName;
            this.status = status;
            this.next = null;
        }
    }

    static class TaskManager {
        Task head;

        public void add(Task newTask) {
            if (head == null) head = newTask;
            else {
                Task temp = head;
                while (temp.next != null) temp = temp.next;
                temp.next = newTask;
            }
        }

        public Task search(int id) {
            Task temp = head;
            while (temp != null) {
                if (temp.taskId == id) return temp;
                temp = temp.next;
            }
            return null;
        }

        public void traverse() {
            Task temp = head;
            while (temp != null) {
                System.out.println(temp.taskId + " | " + temp.taskName + " | " + temp.status);
                temp = temp.next;
            }
        }

        public void delete(int id) {
            if (head == null) return;
            if (head.taskId == id) {
                head = head.next;
                return;
            }
            Task prev = head, curr = head.next;
            while (curr != null) {
                if (curr.taskId == id) {
                    prev.next = curr.next;
                    return;
                }
                prev = curr;
                curr = curr.next;
            }
        }
    }

    public static void main(String[] args) {
        TaskManager manager = new TaskManager();

        manager.add(new Task(1, "Design UI", "Pending"));
        manager.add(new Task(2, "Build Backend", "In Progress"));
        manager.add(new Task(3, "Deploy App", "Pending"));

        System.out.println("All Tasks:");
        manager.traverse();

        System.out.println("\nSearching for Task with ID 2:");
        Task found = manager.search(2);
        System.out.println(found.taskId + " | " + found.taskName + " | " + found.status);

        manager.delete(2);
        System.out.println("\nAfter Deleting Task ID 2:");
        manager.traverse();
    }
}

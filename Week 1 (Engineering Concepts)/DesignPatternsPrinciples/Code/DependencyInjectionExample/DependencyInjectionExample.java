interface CustomerRepo {
    void find(int id);
}

class CustomerRepoImpl implements CustomerRepo {
    public void find(int id) {
        System.out.println("Finding customer " + id);
    }
}

class CustomerService {
    private CustomerRepo repo;
    CustomerService(CustomerRepo r) { this.repo = r; }
    void getCustomer(int id) { repo.find(id); }
}

class DependencyInjectionExample {
    public static void main(String[] args) {
        CustomerService service = new CustomerService(new CustomerRepoImpl());
        service.getCustomer(123);
    }
}

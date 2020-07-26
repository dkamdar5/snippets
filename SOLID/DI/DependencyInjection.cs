namespace DependencyInjection {
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }

    public class EmployeeDAL : IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> ListEmployees = new List<Employee>();
            
            //Get the Employees from the Database (hard coded example)
            ListEmployees.Add(new Employee() { ID = 1, Name = "Josh", Department = "IT" });
            ListEmployees.Add(new Employee() { ID = 2, Name = "Matt", Department = "HR" });
            ListEmployees.Add(new Employee() { ID = 3, Name = "Brian", Department = "Payroll" });

            return ListEmployees;
        }
    }

    public class EmployeeBL
    {
        public IEmployeeDAL _employeeDAL;
        
        public EmployeeBL(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeDAL.SelectAllEmployees();
        }
    }

    class Program {
        static void Main(string[] args) {
            EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
            List<Employee> employees = employeeBL.GetAllEmployees();

            foreach (Employee emp in employees) {
                Console.WriteLine("ID: {0}, Name: {1}, Department: {2}",
                    emp.ID, emp.Name, emp.Department);
                Console.ReadKey();
            }
        }
    }
}
namespace Lab1.Models
{
    //Builder Pattern for objects with various optional properties
    public class Employee : EmployeeAbstract
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        private Employee() { }

        public class EmployeeBuilder
        {
            private readonly Employee _employee;

            public EmployeeBuilder()
            {
                _employee = new Employee();
            }

            public EmployeeBuilder SetName(string name)
            {
                _employee.Name = name;
                return this;
            }

            public EmployeeBuilder SetPosition(string position)
            {
                _employee.Position = position;
                return this;
            }

            public EmployeeBuilder SetSalary(double salary)
            {
                _employee.Salary = salary;
                return this;
            }

            public Employee Build()
            {
                return _employee;
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Employee: {Name}, Position: {Position}, Salary: {Salary}");
        }
    }
}
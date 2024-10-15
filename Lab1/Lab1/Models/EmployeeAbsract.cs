namespace Lab1.Models
{
    // Abstract Employee class
    public abstract class EmployeeAbstract
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public abstract void DisplayInfo();
    }
}
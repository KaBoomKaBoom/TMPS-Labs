namespace Lab1.Models
{
    // Concrete Contractor class
    public class Contractor : EmployeeAbstract
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"Contractor: {Name}, Position: {Position}, Hourly Rate: {Salary}");
        }
    }
}
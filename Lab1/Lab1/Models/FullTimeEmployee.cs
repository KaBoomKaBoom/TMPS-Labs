// Concrete FullTimeEmployee class
namespace Lab1.Models
{

    public class FullTimeEmployee : EmployeeAbstract
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"Full-Time Employee: {Name}, Position: {Position}, Salary: {Salary}");
        }
    }
}
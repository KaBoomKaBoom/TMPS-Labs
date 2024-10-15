using Lab1.Models;

namespace Lab1.Interfaces
{
    //Factory Method Pattern to create different types of employees, 
    //such as FullTimeEmployee and Contractor, based on specific requirements
    
    // EmployeeFactory interface
    public interface IEmployeeFactory
    {
        EmployeeAbstract CreateEmployee(string name, string position, double salary);
    }
}
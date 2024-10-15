using Lab1.Interfaces;
using Lab1.Models;

namespace Lab1.Factories
{
    // FullTimeEmployeeFactory implementation
    public class FullTimeEmployeeFactory : IEmployeeFactory
    {
        public EmployeeAbstract CreateEmployee(string name, string position, double salary)
        {
            return new FullTimeEmployee { Name = name, Position = position, Salary = salary };
        }
    }
}
using Lab1.Interfaces;
using Lab1.Models;

namespace Lab1.Factories
{
    // ContractorFactory implementation
    public class ContractorFactory : IEmployeeFactory
    {
        public EmployeeAbstract CreateEmployee(string name, string position, double hourlyRate)
        {
            return new Contractor { Name = name, Position = position, Salary = hourlyRate };
        }
    }
}
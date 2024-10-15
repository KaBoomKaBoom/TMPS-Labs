namespace Lab1.Models
{
    //Prototype Pattern to create new employee instances by copying existing ones
    public class EmployeePrototype : ICloneable
    {
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
        public double Salary { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
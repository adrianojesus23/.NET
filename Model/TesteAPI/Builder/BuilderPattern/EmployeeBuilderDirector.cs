namespace Builder.BuilderPattern
{
    public class EmployeeBuilderDirector : EmployeeSalaryBuilder<EmployeeBuilderDirector>
    {
        public static EmployeeBuilderDirector employeeBuilder => new();
    }
}

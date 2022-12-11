namespace Company.Data.Entities;

public class EmployeesJobTitle : IReferenceEntity
{
    public int EmployeeId { get; set; }
    public int JobTitleId { get; set; }
    public virtual Employee? Employees { get; set; }
    public virtual JobTitle? JobTitle { get; set; }
}

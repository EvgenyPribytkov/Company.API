namespace Company.Common.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal Salary { get; set; }
    public bool IsUnionMember { get; set; }
    public int DepartmentId { get; set; }
}

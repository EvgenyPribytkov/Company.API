namespace Company.Data.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string? FirstName { get; set; }
    [MaxLength(50), Required]
    public string? LastName { get; set; }
    [Precision(18, 2), Required]
    public decimal Salary { get; set; }
    [Required]
    public bool IsUnionMember { get; set; }
    [Required]
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public virtual ICollection<JobTitle>? JobTitles { get; set; }
}

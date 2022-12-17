namespace Company.Data.Entities;

public class JobTitle : IEntity
{
    [Required]
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string? JobTitleName { get; set; }
    public virtual ICollection<Employee>? Employees { get; set; }
}

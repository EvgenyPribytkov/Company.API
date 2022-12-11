using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class Department : IEntity
{
    [Required]
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string? DepartmentsName { get; set; }
    [Required]
    public int OrganisationId { get; set; }
    public Organisation? Organisation { get; set; }
}

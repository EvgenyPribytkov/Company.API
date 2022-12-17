namespace Company.Data.Entities;

public class Organisation : IEntity
{
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string? OrganisationName { get; set; }
}

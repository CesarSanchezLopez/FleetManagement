namespace FleetManagement.Application.DTOs.Companies;

public class CompanyDto
{
    public Guid? Id { get; set; } // Null en Create
    public string Name { get; set; } = string.Empty;
    public string Nit { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } // Solo se devuelve en GET
}
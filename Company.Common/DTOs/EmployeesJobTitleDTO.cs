namespace Company.Common.DTOs; 
public class EmployeesJobTitleDTO 
{
    public int EmployeeId { get; set; }
    public int JobTitleId { get; set; }
    public EmployeesJobTitleDTO(int employeeId, int jobTitleId)
    {
        EmployeeId = employeeId;
        JobTitleId = jobTitleId;
    }
}

namespace Company.Data.Contexts;

public class CompanyContext : DbContext
{
    public DbSet<Organisation> Organisations => Set<Organisation>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<JobTitle> JobTitles => Set<JobTitle>();
    public DbSet<EmployeesJobTitle> EmployeesJobTitles =>
Set<EmployeesJobTitle>();
    public CompanyContext(DbContextOptions<CompanyContext> options)
: base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<EmployeesJobTitle>().HasKey(ej =>
            new { ej.EmployeeId, ej.JobTitleId });
        SeedData(builder);
    }
    private void SeedData(ModelBuilder builder)
    {
        var companies = new List<Organisation>
        {
            new Organisation {
                Id = 1,
                OrganisationName = "Apple"
            },
            new Organisation {
                Id = 2,
                OrganisationName = "Google"
            },
            new Organisation {
                Id = 3,
                OrganisationName = "Facebook"
            },
        };
        builder.Entity<Organisation>().HasData(companies); 
        var departments = new List<Department>
        {
            new Department {
            Id = 1,
            DepartmentsName = "Marketing",
            OrganisationId = 1
            },
            new Department {
            Id = 2,
            DepartmentsName = "Sales",
            OrganisationId = 1
            },
            new Department {
            Id = 3,
            DepartmentsName = "Customer Service",
            OrganisationId = 1
            },
            new Department {
            Id = 4,
            DepartmentsName = "IT",
            OrganisationId = 1
            }
        };
        builder.Entity<Department>().HasData(departments);
        var employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "Kenny",
                LastName = "Todd",
                Salary = 2500,
                IsUnionMember = true,
                DepartmentId = 1
            },
            new Employee
            {
                Id = 2,
                FirstName = "Natasha",
                LastName = "Parrish",
                Salary = 2200,
                IsUnionMember = false,
                DepartmentId = 2
            },
            new Employee
            {
                Id = 3,
                FirstName = "Brendon",
                LastName = "Yates",
                Salary = 2800,
                IsUnionMember = true,
                DepartmentId = 3
            },
            new Employee
            {
                Id = 4,
                FirstName = "Terry",
                LastName = "Patrick",
                Salary = 3000,
                IsUnionMember = true,
                DepartmentId = 4
            }
        };
        builder.Entity<Employee>().HasData(employees);
        var jobTitles = new List<JobTitle>
        {
            new JobTitle
            {
                Id = 1,
                JobTitleName = "Marketing Assistant"
            },
            new JobTitle
            {
                Id = 2,
                JobTitleName = "Sales Manager"
            },
            new JobTitle
            {
                Id = 3,
                JobTitleName = "Customer Service Representative"
            },
            new JobTitle
            {
                Id = 4,
                JobTitleName = "Team Lead"
            },
            new JobTitle
            {
                Id = 5,
                JobTitleName = "Developer"
            }
        };
        builder.Entity<JobTitle>().HasData(jobTitles);
        var employeesJobTitles = new List<EmployeesJobTitle>
        {
            new EmployeesJobTitle
            {
                EmployeeId = 1,
                JobTitleId = 1
            },
            new EmployeesJobTitle
            {
                EmployeeId = 2,
                JobTitleId = 2
            },
            new EmployeesJobTitle
            {
                EmployeeId = 3,
                JobTitleId = 3
            },
            new EmployeesJobTitle
            {
                EmployeeId = 4,
                JobTitleId = 4
            },
            new EmployeesJobTitle
            {
                EmployeeId = 4,
                JobTitleId = 5
            },
        };
        builder.Entity<EmployeesJobTitle>().HasData(employeesJobTitles);
    }
}

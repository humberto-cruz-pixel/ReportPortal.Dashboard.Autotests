using TestProject.Interfaces.Models.Dashboard;

namespace TestProject.Models.Dashboard;

internal class DashboardCreation : IDashboardCreation
{
    public string Name { get; set; }
    public string Description { get; set; }
}

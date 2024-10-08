using TestProject.Interfaces.Models.Dashboard;

namespace TestProject.Models.Dashboard;

internal class DashboardCreation : IDashboardCreation
{
    public string name { get; set; }
    public string description { get; set; }
}

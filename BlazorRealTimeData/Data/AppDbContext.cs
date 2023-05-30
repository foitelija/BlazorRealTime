using Microsoft.EntityFrameworkCore;

namespace BlazorRealTimeData.Data
{
    public class AppDbContext : DbContext
    {
        string _connectionString = "";
    }
}

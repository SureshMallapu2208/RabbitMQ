using Microsoft.EntityFrameworkCore;
using RabbitMQ.Models;

namespace RabbitMQ
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts) { }

        public DbSet<Request> Requests { get; set; }
    }
}

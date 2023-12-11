using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class FormResponseContext : DbContext
    {
        public FormResponseContext(DbContextOptions<FormResponseContext> options)
            : base(options)
        {
        }

        public DbSet<FormResponse> FormResponses { get; set; }
    }
}
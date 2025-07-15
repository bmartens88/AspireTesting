using Microsoft.EntityFrameworkCore;

namespace AspireTest.Data.Data;

public sealed class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos => Set<Todo>();
}
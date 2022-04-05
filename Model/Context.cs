namespace Model;
using Microsoft.EntityFrameworkCore;


class AppDbContext : DbContext{
    // mapeamento da entidade para a tabela
    public DbSet<Address> addresses {get; set;}
    public DbSet<Client> clients {get; set;}
    public DbSet<Owner> owners {get; set;}
    public DbSet<Person> persons {get; set;}
    public DbSet<Product> products {get; set;}
    public DbSet<Purchase> purchases {get; set;}
    public DbSet<Stocks> stocks {get; set;}
    public DbSet<Store> stores {get; set;}
    public DbSet<WishList> wishlists {get; set;}

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

        optionsBuilder.UseSqlServer("Data Source = JVLPC0553;" + "Initial Catalog = MarketPlace; Integrated Security=True");

        //dotnet ef dbcontext scaffold "Data Source = JVLPC0553;" + "Initial Catalog = MarketPlace; Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer


        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //     modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        // }
    }
}


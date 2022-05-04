namespace DAO;
using Microsoft.EntityFrameworkCore;



public class DAOContext : DbContext
{
    // mapeamento da entidade para a tabela
    public DbSet<Address> addresses { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Owner> owners { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Purchase> purchases { get; set; }
    public DbSet<Stocks> stocks { get; set; }
    public DbSet<Store> stores { get; set; }
    public DbSet<WishList> wishlists { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=JVLPC0497;" + "Initial Catalog=MarketPlace; Integrated Security=True");
        //optionsBuilder.UseSqlServer("Data Source=JVLPC0553;" + "Initial Catalog=MarketPlace; Integrated Security=True");
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.street);
            entity.Property(e => e.city);
            entity.Property(e => e.state);
            entity.Property(e => e.country);
            entity.Property(e => e.postal_code);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name);
            entity.Property(e => e.bar_code);
        });

        modelBuilder.Entity<Stocks>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.quantity);
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.product);
            entity.Property(e => e.unit_price);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name);
            entity.Property(e => e.date_of_birth);
            entity.Property(e => e.document);
            entity.Property(e => e.email);
            entity.Property(e => e.phone);
            entity.Property(e => e.login);
            entity.Property(e => e.passwd);
            entity.HasOne(d => d.address);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.date_purchase);
            entity.Property(e => e.payment_type);
            entity.Property(e => e.purchase_status);
            entity.Property(e => e.purchase_values);
            entity.Property(e => e.number_confirmation);
            entity.Property(e => e.number_nf);
            entity.HasOne(d => d.client);
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.product);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name);
            entity.Property(e => e.date_of_birth);
            entity.Property(e => e.document);
            entity.Property(e => e.email);
            entity.Property(e => e.phone);
            entity.Property(e => e.login);
            entity.Property(e => e.passwd);
            entity.HasOne(d => d.address);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name);
            entity.Property(e => e.CNPJ);
            entity.HasOne(d => d.owner);
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.HasOne(d => d.product);
            entity.HasOne(d => d.client);
        });

    }
}


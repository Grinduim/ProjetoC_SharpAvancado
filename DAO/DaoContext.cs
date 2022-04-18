namespace DAO;
using Microsoft.EntityFrameworkCore;



public class DaoContext : DbContext
{
    // mapeamento da entidade para a tabela
    public DbSet<Address> addresses { get; set; }
    public DbSet<Client> clients { get; set; }
    public DbSet<Owner> owners { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Purchase> purchases { get; set; }
    public DbSet<Stocks> stocks { get; set; }
    public DbSet<Store> stores { get; set; }
    public DbSet<WishList> wishlists { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = JVLPC0553;" + "Initial Catalog = MarketPlace; Integrated Security=True");
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.street).IsRequired();
            entity.Property(e => e.city).IsRequired();
            entity.Property(e => e.state).IsRequired();
            entity.Property(e => e.country).IsRequired();
            entity.Property(e => e.poste_code).IsRequired();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.unit_price).IsRequired();
            entity.Property(e => e.bar_code).IsRequired();
        });

        modelBuilder.Entity<Stocks>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.quantity).IsRequired();
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.product);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.date_of_birth).IsRequired();
            entity.Property(e => e.document).IsRequired();
            entity.Property(e => e.email).IsRequired();
            entity.Property(e => e.phone).IsRequired();
            entity.Property(e => e.login).IsRequired();
            entity.Property(e => e.passwd).IsRequired();
            entity.HasOne(d => d.address);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.date_purchase).IsRequired();
            entity.Property(e => e.payment_type).IsRequired();
            entity.Property(e => e.purchase_status).IsRequired();
            entity.Property(e => e.purchase_values).IsRequired();
            entity.Property(e => e.number_confirmation).IsRequired();
            entity.Property(e => e.number_nf).IsRequired();
            entity.HasOne(d => d.client);
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.products);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.date_of_birth).IsRequired();
            entity.Property(e => e.document).IsRequired();
            entity.Property(e => e.email).IsRequired();
            entity.Property(e => e.phone).IsRequired();
            entity.Property(e => e.login).IsRequired();
            entity.Property(e => e.passwd).IsRequired();
            entity.HasOne(d => d.address);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.CNPJ).IsRequired();
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


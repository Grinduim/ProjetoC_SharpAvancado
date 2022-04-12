using DAO;

using (var context = new DaoContext())
{
    context.Database.EnsureCreated();

    context.addresses.Add(new Address
    {
        street = "travessa bunda",
        city = "Colombo",
        state = "Paraná",
        country = "Brasil",
        poste_code = "8340869"
    });

    context.SaveChanges();
}




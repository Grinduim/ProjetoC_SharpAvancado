using DAO;

using(var context = new DaoContext()){
    context.Database.EnsureCreated();

    context.addresses.add(new Address{
        street = "genoveva forlepa kopka 213",
        city = "Pinhais",
        state = "Paraná",
        country = "Brasil",
        poste_code = "83320560"  
    });
    
    context.SaveChanges();
}




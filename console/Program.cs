using DAO;

using (var context = new DaoContext())
{
    context.Database.EnsureCreated();
}




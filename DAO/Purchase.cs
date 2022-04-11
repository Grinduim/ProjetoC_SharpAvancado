namespace DAO;
using Microsoft.EntityFrameworkCore;
public class Purchase 
{
    public int id;
    public DateTime date_purchase;
    public int payment_type;
    public int purchase_status;
    public double purchase_values; 
    public String number_confirmation ;
    public String number_nf;
    public Client client;
    public Store store;
    public Product products;
}


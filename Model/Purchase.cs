namespace Model;
public class Purchase
{
    private DateTime date_purchase;
    private String payment= "";
    private String number_confirmation = "";
    private String number_nf= "";
    private Client client;
    private List<Product> products = new List<Product>();
    private List<Store> stores = new List<Store>();

     
}


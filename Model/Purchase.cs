namespace Model;
public class Purchase
{
    private DateTime date_purchase;
    private String payment= "";
    private String number_confirmation = "";
    private String number_nf= "";
    private Client client;
    private Store stores;
    private List<Product> products = new List<Product>();


    public Purchase(Client client, Store stores)
    {
        this.client = client;
        this.stores = stores;
    }

    public DateTime getDatePurchase(){return this.date_purchase;}
    public void setDatePurchase(DateTime date_purchase){this.date_purchase = date_purchase;}


    public String getPayment(){return this.payment;}
    public void setPayment(string payment){this.payment = payment;}


    public String getNumberConfirmation(){return this.number_confirmation;}
    public void setNumberConfirmation(string number_confirmation){this.number_confirmation = number_confirmation;}


    public String getNumberNf(){return this.number_nf;}
    public void setNumberNf(string number_nf){this.number_nf = number_nf;}


    public Client GetClient(){return this.client;}
    public void setClient(Client client){this.client = client;}

    public Store GetStores(){return this.stores;}
    public void setStores(Store stores){this.stores = stores;}
    

    public List<Product> GetProducts(){return this.products;}
    public void setProducts(List<Product> products){this.products = products;}
}


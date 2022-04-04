using Enums;
namespace Model;
public class Purchase
{
    private DateTime date_purchase;
    private int payment;
    private int purchase_status;
    public double purchase_values = 0; 
    private String number_confirmation = "";
    private String number_nf= "";
    private Client client;
    private Store stores;
    private List<Product> products = new List<Product>();


    public DateTime getDataPurchase(){return this.date_purchase;}
    public void setDataPurchase(DateTime date_purchase){this.date_purchase = date_purchase;}


    public int getPaymentType(){return this.payment;}
    public void setPaymentType(PaymentEnum payment){this.payment = (int) payment;}


    public String getNumberConfirmation(){return this.number_confirmation;}
    public void setNumberConfirmation(string number_confirmation){this.number_confirmation = number_confirmation;}


    public String getNumberNf(){return this.number_nf;}
    public void setNumberNf(string number_nf){this.number_nf = number_nf;}


    public Client GetClient(){return this.client;}
    public void setClient(Client client){this.client = client;}

    public Store GetStores(){return this.stores;}
    public void setStores(Store stores){this.stores = stores;}
    

    public List<Product> getProducts(){return this.products;}
    public void setProducts(List<Product> products){this.products = products;}


    public int getPurchaseStatus() => purchase_status;
    public void setPurchaseStatus(PurchaseStatusEnum purchase_status){this.purchase_status = (int) purchase_status;}


    public double getPurchaseValues() => purchase_values;
    public void setPurchaseValues(double purchase_values){this.purchase_values = purchase_values;}
}


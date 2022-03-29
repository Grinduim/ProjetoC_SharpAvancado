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

    public DateTime getDatePurchase()
    {
        return this.date_purchase;
    }
    public void setDatePurchase(DateTime date_purchase)
    {
        this.date_purchase = date_purchase;
    }


    public String getPayment()
    {
        return this.payment;
    }
    public void setPayment(string payment)
    {
        this.payment = payment;
    }


    public String getNumberConfirmation()
    {
        return this.number_confirmation;
    }
    public void setNumberConfirmation(string number_confirmation)
    {
        this.number_confirmation = number_confirmation;
    }


    public String getNumberNf()
    {
        return this.number_nf;
    }
    public void setNumberNf(string number_nf)
    {
        this.number_nf = number_nf;
    }


    public Client GetClient()
    {
        return this.client;
    }
    public void setClient(Client client)
    {
        this.client = client;
    }
    //Allan, em vez de criar um get e set de client, cria um construtor de purchase que recebe esse objeto!!!!
    //Assim voce lida com a dependencia e garante que purchase obrigatoriamente tem um client
}


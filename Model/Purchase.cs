using Enums;
namespace Model;
using Interfaces;
using Microsoft.EntityFrameworkCore;
public class Purchase : IValidateDataObject<Purchase>
{
    private DateTime date_purchase;
    private int payment_type;
    private int purchase_status;
    public double purchase_values = 0;
    private String number_confirmation;
    private String number_nf = "";
    private Client client;
    private Store stores;
    private List<Product> products = new List<Product>();


    public DateTime getDataPurchase() { return this.date_purchase; }
    public void setDataPurchase(DateTime date_purchase) { this.date_purchase = date_purchase; }


    public int getPaymentType() { return this.payment_type; }
    public void setPaymentType(PaymentEnum payment_type) { this.payment_type = (int)payment_type; }


    public String getNumberConfirmation() { return this.number_confirmation; }
    public void setNumberConfirmation(string number_confirmation) { this.number_confirmation = number_confirmation; }


    public String getNumberNf() { return this.number_nf; }
    public void setNumberNf(string number_nf) { this.number_nf = number_nf; }


    public Client GetClient() { return this.client; }
    public void setClient(Client client) { this.client = client; }

    public Store GetStores() { return this.stores; }
    public void setStores(Store stores) { this.stores = stores; }


    public List<Product> getProducts() { return this.products; }
    public void setProducts(List<Product> products) { this.products = products; }


    public int getPurchaseStatus() => purchase_status;
    public void setPurchaseStatus(PurchaseStatusEnum purchase_status) { this.purchase_status = (int)purchase_status; }


    public double getPurchaseValues() => purchase_values;
    public void setPurchaseValues(double purchase_values) { this.purchase_values = purchase_values; }


    public Boolean validateObject(Purchase obj)
    {

        if (obj.getDataPurchase() == null) return false;
        if (obj.getNumberConfirmation() == null) return false;
        if (obj.getNumberNf() == null) return false;
        if (obj.getProducts() == null) return false;
        if (obj.getPurchaseValues() == 0) return false;
        if (obj.GetClient() == null) return false;
        if (obj.GetStores() == null) return false;

        return true;
    }

    public void updateStatus(int PurchaseStatusEnum)
    {
        this.purchase_status = PurchaseStatusEnum;
    }
}


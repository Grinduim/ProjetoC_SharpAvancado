using Enums;
namespace Model;
using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;
public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
{
    private DateTime date_purchase;
    private int payment_type;
    private int purchase_status;
    private double purchase_value = 0;
    private String number_confirmation;
    private String number_nf = "";
    private Client client;
    private Store store;

    private List<PurchaseDTO> purchaseDTO = new List<PurchaseDTO>();
    private List<Product> products = new List<Product>();

    public void updateStatus(int PurchaseStatusEnum)
    {
        this.purchase_status = PurchaseStatusEnum;
    }

    public static Purchase convertDTOToModel(PurchaseDTO obj)
    {
        
        var purchase = new Purchase();
        purchase.client = Client.convertDTOToModel(obj.client);
        purchase.date_purchase = obj.data_purchase;
        purchase.purchase_value = obj.purchase_value;
        purchase.payment_type = obj.payment_type;
        purchase.purchase_status = obj.purchase_status;
        purchase.number_confirmation = obj.number_confirmation;
        purchase.number_nf = obj.number_nf;

        return purchase;
    }


    public void delete()
    {

    }

    public int save()
    {
        var id = 0;
        using (var context = new DAOContext())
        {
            var clientDAO =  context.Client.FirstOrDefault(c => c.id == 1);
            var storeDAO = context.stores.FirstOrDefault(s =>s.id ==1);
            var productsDAO = context.products.Where(p => p.id == 1).Single();
            
            var purchase = new DAO.Purchase {
                date_purchase = this.date_purchase,
                payment_type = this.payment_type,
                purchase_status = this.purchase_status,
                purchase_values = this.purchase_value,
                number_confirmation = this.getNumberConfirmation(),
                number_nf = this.getNumberNf(),
                client = clientDAO,
                store = storeDAO,
                product = productsDAO
            };
            
            context.purchases.Add(purchase);
            context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = purchase.id;
            
            
        };
        return id;
    }

    public void update(PurchaseDTO obj){

    }

    public PurchaseDTO findById(int id){
        return new PurchaseDTO();
    }

    public List<PurchaseDTO> getAll(){
        return this.purchaseDTO;
    }

    public PurchaseDTO convertModelToDTO(){
        var purchaseDTO = new PurchaseDTO();
        purchaseDTO.data_purchase = this.date_purchase;
        purchaseDTO.payment_type = this.payment_type;
        purchaseDTO.purchase_status = this.purchase_status;
        purchaseDTO.purchase_value = this.purchase_value;
        purchaseDTO.number_confirmation = this.number_confirmation;
        purchaseDTO.number_nf = this.number_nf;
        purchaseDTO.client = this.client.convertModelToDTO();

        return purchaseDTO;
    }

    public Boolean validateObject()
    {
  
        if (this.getDataPurchase() == null) return false;
        if (this.getNumberConfirmation() == null) return false;
        if (this.getNumberNf() == null) return false;
        if (this.getPurchaseValues() == 0) return false;

        return true;
    }

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

    public Store GetStore() { return this.store; }
    public void setStore(Store stores) { this.store = stores; }


    public List<Product> getProducts() { return this.products; }
    public void setProducts(List<Product> products) { this.products = products; }


    public int getPurchaseStatus() => purchase_status;
    public void setPurchaseStatus(PurchaseStatusEnum purchase_status) { this.purchase_status = (int)purchase_status; }


    public double getPurchaseValues() => purchase_value;
    public void setPurchaseValues(double purchase_values) { this.purchase_value = purchase_values; }

}


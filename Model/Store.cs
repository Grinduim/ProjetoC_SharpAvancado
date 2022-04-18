namespace Model;
using Interfaces;

public class Store : IValidateDataObject<Store>
{
    private String name;
    private String CNPJ;
    private Owner owner;
    private List<Purchase> purchases = new List<Purchase>();


    public Store(Owner owner) { this.owner = owner; }


    public String getName() { return this.name; }
    public void setName(string name) { this.name = name; }

    public String getCNPJ() { return this.CNPJ; }
    public void setCNPJ(String CNPJ) { this.CNPJ = CNPJ; }

    public Owner getOwner() { return this.owner; }


    public List<Purchase> getPurchases() { return purchases; }
    public void addNewPurchase(Purchase purchase)
    { //add list to wishlist
        if (!getPurchases().Contains(purchase))
        { // se a lista nao conter o produto na lusta
            this.purchases.Add(purchase);// adicionar ela na lista
        }
    }

    public Boolean validateObject(Store obj)
    {

        if (obj.getName() == null) return false;
        if (obj.getCNPJ() == null) return false;
        if (obj.getOwner() == null) return false;
        if (obj.getPurchases() == null) return false;
        return true;
    }


    



}

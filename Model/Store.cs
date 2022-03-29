namespace Model;
public class Store
{
    private String name = "";
    private String CNPJ = "";
    private Owner owner;
    private List<Purchase> purchases = new List<Purchase>();


    public Store(Owner owner){this.owner = owner;}


    public String getName(){return this.name;}
    public void setName(string name){this.name = name;}

    public String getCNPJ(){return this.CNPJ;}
    public void setCNPJ(String CNPJ){this.CNPJ = CNPJ;}

    public Owner getOwner(){return this.owner;}


    public List<Purchase> getPurchases(){return purchases;}
    public void addNewPurchase(Purchase purchase){ //add list to wishlist
        if(!getPurchases().Contains(purchase)){ // se a lista nao conter o produto na lusta
            this.purchases.Add(purchase);// adicionar ela na lista
        }
    }

}

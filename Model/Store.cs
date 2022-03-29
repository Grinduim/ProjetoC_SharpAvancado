namespace Model;
public class Store
{
    private String name = "";
    private String CNPJ = "";
    private Owner owner;
    private List<Purchase> purchases = new List<Purchase>();

    public void setName(string name){
        this.name = name;
    }
    
    public List<Purchase> getPurchases(){
        return purchases;
    }

    public void addNewPurchase(Purchase purchase){ //add list to wishlist

        if(!getPurchases().Contains(purchase)){ // se a lista nao conter o produto na lusta
            this.purchases.Add(purchase);// adicionar ela na lista
        }
    }

}

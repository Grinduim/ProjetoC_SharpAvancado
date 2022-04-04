namespace Model;
public class WishList
{
    private List<Product> products = new List<Product>();
    private Client client;


    public WishList(Client client){
        this.client = client;
     }
    public void setClient( Client client){this.client = client;}
    public Client getClient(){return this.client;}
    
    public List<Product> getProducts(){return products;}
    public void addProductToWishList(Product product){ 
        if(!getProducts().Contains(product)){ 
            this.products.Add(product);
        }
    }
}

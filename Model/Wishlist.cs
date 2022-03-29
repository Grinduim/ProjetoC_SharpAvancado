namespace Model;
public class Wishlist
{
    private List<Product> products = new List<Product>();
    private Client client;

    public Wishlist(Client client){this.client = client;}

    public void setClient( Client client){this.client = client;}
    public Client getClient(Client client){return this.client;}

    public List<Product> getProducts(){return products;}
    public void addProductToWishList(Product product){ 
        if(!getProducts().Contains(product)){ 
            this.products.Add(product);
        }
    }
}

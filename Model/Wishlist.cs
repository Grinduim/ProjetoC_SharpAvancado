namespace Model;
public class Wishlist
{
    private List<Product> products = new List<Product>();
    Client client;
    

    public List<Product> Products { get => products; set => products = value; }
    public Client Client { get => client; set => client = value; }

    public void addProductToWishList(Product product){
        Products.Add(product);
    }
}

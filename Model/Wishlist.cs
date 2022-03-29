namespace Model;
public class Wishlist
{
    private List<Product> products = new List<Product>();

    public List<Product> Products { get => products; set => products = value; }

    public void addProductToWishList(Product product){
        Products.Add(product);
    }
}

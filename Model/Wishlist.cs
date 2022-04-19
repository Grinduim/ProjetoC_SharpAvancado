namespace Model;
using Interfaces;
public class WishList : IValidateDataObject, IDataController<OwnerDTO, Owner>
{
    private List<Product> products = new List<Product>();
    private Client client;


    public WishList(Client client)
    {
        this.client = client;
    }



    public void setClient(Client client) { this.client = client; }
    public Client getClient() { return this.client; }

    public List<Product> getProducts() { return products; }
    public void addProductToWishList(Product product)
    {
        if (!getProducts().Contains(product))
        {
            this.products.Add(product);
        }
    }
    public Boolean validateObject(WishList obj)
    {

        if (obj.getClient() == null) return false;
        if (obj.getProducts() == null) return false;
        return true;
    }

}

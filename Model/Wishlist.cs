namespace Model;
using Interfaces;
using DAO;
using DTO;
public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
{
    private List<Product> products = new List<Product>();
    private Client client;
    public List<WishListDTO> wishListDTO = new List<WishListDTO>();

    public WishList(Client client)
    {
        this.client = client;
    }


    public WishList()
    {
    }
    public static WishList convertDTOToModel(WishListDTO obj)
    {

        var wishList = new WishList(Client.convertDTOToModel(obj.client));

        foreach (var prod in obj.product)
        {
            wishList.addProductToWishList(Product.convertDTOToModel(prod));
        }

        return wishList;
    }

    public void delete()
    {

    }
    public int save(string document, int productId)
    {
        var id = 0;

        using (var context = new DAOContext())
        {

            var clientDAO = context.Client.FirstOrDefault(c => c.document == document);
            var productDAO = context.products.Where(c => c.id == productId).Single();

            var wishList = new DAO.WishList
            {
                client = clientDAO,
                product = productDAO
            };

            context.wishlists.Add(wishList);

            context.SaveChanges();

            id = wishList.id;

        }
        return id;
    }

    public void update(WishListDTO obj)
    {

    }

    public WishListDTO findById(int id)
    {

        return new WishListDTO();
    }

    public List<WishListDTO> getAll()
    {
        return this.wishListDTO;
    }


    public WishListDTO convertModelToDTO()
    {
        var wishListDTO = new WishListDTO();

        wishListDTO.client = this.client.convertModelToDTO();

        foreach (var prod in this.products)
        {
            wishListDTO.product.Add(prod.convertModelToDTO());
        }



        return wishListDTO;
    }

    public Boolean validateObject()
    {

        if (this.getClient() == null) return false;
        if (this.getProducts() == null) return false;
        return true;
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

}

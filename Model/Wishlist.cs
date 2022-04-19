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

    public static WishList convertDTOToModel(WishListDTO obj)
    {
        return new WishList(Client.convertDTOToModel(obj.client));
    }

    public void delete(WishListDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {

            var product = new DAO.Product{
                name = this.products.getName(),
                bar_code = this.products.getBarCode()
            };  

            var address = new DAO.

            
            var client = new DAO.Client{
                name = this.client.getName(),
                date_of_birth = this.client.getDateOfBirth(),
                document = this.client.getDocument(),
                email = this.client.getEmail(),
                phone = this.client.getPhone(),
                login = this.client.getLogin(),
                address =this.client.getAddress()
            };

            var wishList = new DAO.WishList{
                client = client,
                product = product
            };

            context.addresses.Add(wishList);

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
        return this.WishListDTO;      
    }

   
    public WishListDTO convertModelToDTO()
    {
        var WishListDTO = new WishListDTO();

        WishListDTO.street = this.street;

        WishListDTO.state = this.state;

        WishListDTO.city = this.city;

        WishListDTO.country = this.country;

        WishListDTO.poste_code = this.poste_code;

        return WishListDTO;
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

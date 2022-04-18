namespace Model;
using DTO;
using DAO;
using Interfaces;
public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
{
    private int quantity;
    private Store store;
    private Product product;
    public List<StocksDTO> stocksDTO = new List<StocksDTO>();

    public Stocks() { }
    public Stocks(Store store, Product product) { this.store = store; this.product = product; }


   
    public static Stocks convertDTOToModel(StocksDTO obj)
    {
        return new Stocks();
    }

    public void delete(StocksDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var store = new DAO.Store{

            };

            var product = new DAO.Product{

            };


            var address = new DAO.Address{
                quantity = this.quantity,
                store = store,
                product =product,
                
            };

            context.addresses.Add(address);

            context.SaveChanges();

            id = address.id;

        }
         return id;
    }

    public void update(StocksDTO obj)
    {

    }

    public StocksDTO findById(int id)
    {

        return new StocksDTO();
    }

    public List<StocksDTO> getAll()
    {        
        return this.StocksDTO;      
    }

   
    public StocksDTO convertModelToDTO()
    {
        var StocksDTO = new StocksDTO();

        StocksDTO.street = this.street;

        StocksDTO.state = this.state;

        StocksDTO.city = this.city;

        StocksDTO.country = this.country;

        StocksDTO.poste_code = this.poste_code;

        return StocksDTO;
    }




    public Boolean validateObject()
    {
        if (this.getQuantity() == 0) return false;
        if (this.getStore() == null) return false;
        if (this.getProduct() == null) return false;
        return true;
    }



     public void setQuantity(int quantity) { this.quantity = quantity; }
    public int getQuantity() { return this.quantity; }


    public Store getStore() { return this.store; }
    public void setStore(Store strore) { this.store = strore; }


    public void setProduct(Product product) { this.product = product; }
    public Product getProduct() { return this.product; }
}



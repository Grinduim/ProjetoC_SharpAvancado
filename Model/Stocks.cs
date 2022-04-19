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

    private double unit_price;

    public Stocks() { }
    public Stocks(Store store, Product product) { this.store = store; this.product = product; }


   
    public static Stocks convertDTOToModel(StocksDTO obj)
    {  
        var stocks = new Stocks();
        stocks.quantity = obj.quantity;
        stocks.unit_price = obj.unit_price;
        stocks.product = Product.convertDTOToModel(obj.productDTO);
        stocks.store = Store.convertDTOToModel(obj.store);
        return stocks;
    }

    public void delete(StocksDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {

            var store =  context.stores.FirstOrDefault(s=>s.id==1);
            var product = context.products.FirstOrDefault(p=>p.id==1);
            var stocks = new DAO.Stocks{
                quantity = this.getQuantity(),
                unit_price = this.getUnitPrice(),   
                product = product,
                store = store,
            };
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
        return this.stocksDTO;      
    }

   
    public StocksDTO convertModelToDTO()
    {
        var stocksDTO = new StocksDTO();

        stocksDTO.quantity = this.getQuantity();
        stocksDTO.unit_price = this.getUnitPrice();
        stocksDTO.productDTO = this.getProduct().convertModelToDTO();
        stocksDTO.store = this.getStore().convertModelToDTO();

        return stocksDTO;
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

    public double getUnitPrice() { return this.unit_price; }
    public void setUnitPrice(double value) { this.unit_price = value; }
    public void setProduct(Product product) { this.product = product; }
    public Product getProduct() { return this.product; }
}



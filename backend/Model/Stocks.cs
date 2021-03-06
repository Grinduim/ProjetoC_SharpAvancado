namespace Model;
using DTO;
using DAO;
using Interfaces;
using Microsoft.EntityFrameworkCore;

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
        Stocks stocks = new Stocks{
            quantity = obj.quantity,
            unit_price = obj.unit_price,
            product = Product.convertDTOToModel(obj.product),
            store = Store.convertDTOToModel(obj.store)
        };
        // stocks.quantity = obj.quantity;
        // stocks.unit_price = obj.unit_price;
        // stocks.product = Product.convertDTOToModel(obj.productDTO);
        // stocks.store = Store.convertDTOToModel(obj.store);
        return stocks;
    }

    public void delete()
    {

    }
    public int save(int lojaId, int productId,  int quantidade, double unit_price)
    {
        var id = 0;

        using(var context = new DAOContext())
        {

            var store =  context.stores.FirstOrDefault(s=>s.id == lojaId);
            var product = context.products.FirstOrDefault(p=>p.id ==productId);

            var stocks = new DAO.Stocks{
                quantity = quantidade,
                unit_price = unit_price,
                product = product,
                store = store
            };
            context.stocks.Add(stocks);

            context.SaveChanges();

            id = stocks.id;
        }
         return id;
    }

    public void update(StocksDTO obj)
    {
        using (var context = new DAOContext())
        {
            var Store = context.stores.FirstOrDefault(s => s.CNPJ == obj.store.CNPJ);
            var Product = context.products.FirstOrDefault(s=> s.bar_code == obj.product.bar_code);

            var stocks = context.stocks.FirstOrDefault(s=> s.product.id == product.getID() && s.store.id == store.getID() );

            if (stocks != null) 
            {
                stocks.quantity = obj.quantity;
                stocks.unit_price = obj.unit_price;
                context.SaveChanges();
            }
           
        }

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
        stocksDTO.product = this.getProduct().convertModelToDTO();
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



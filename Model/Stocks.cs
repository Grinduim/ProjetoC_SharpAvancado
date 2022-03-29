namespace Model;
public class Stocks
{
    private int quantity;
    private Store store;
    private Product product;

    public Stocks(Store store, Product product){ this.store = store; this.product = product;}


    public void setQuantity(int quantity){this.quantity = quantity;}
    public int getQuantity(){return this.quantity;}


    public Store getStore(){return this.store;}
    public void setStore(Store strore){this.store = strore;}


    public void setProduct(Product product){this.product = product;}
    public Product getProduct(){return this.product;}

}



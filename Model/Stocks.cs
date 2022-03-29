namespace Model;
public class Stocks
{
    private int quantity;
    private Store store;
    private Product product;

    public void setQuatity(int quantity)
    {
        this.quantity = quantity;
    }

    public int getQuatity()
    {
        return this.quantity;
    }

    public Store getStore()
    {
        if (this.store != null)
        {
            return (Store)this.store;
        }
        else
        {
            return null;
        }
    }

    public void setStore(Store strore)
    {
        this.store = strore;
    }

    public void setProduct(Product product)
    {
        this.product = product;
    }

    public Product getProduct()
    {
        return this.product;
    }

}



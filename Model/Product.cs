namespace Model;
public class Product
{
    private String name= "";
    private double unit_price;
    private String bar_code= "";
    

    public void setName(String name)
    {
        this.name = name;
    }
    public String getName()
    {
        return this.name;
    }
    public void setUnitPrice(double unit_price)
    {
        this.unit_price = unit_price;
    }

    public double getUnitPrice()
    {
        return this.unit_price;
    }

    public void setBarCode(String bar_code)
    {
        this.bar_code = bar_code;  
    }

    public String getBarCode()
    {
        return this.bar_code;
    }



}


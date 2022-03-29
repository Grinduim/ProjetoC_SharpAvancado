namespace Model;
public class Store
{
    private String name = "";
    private String CNPJ = "";
    private Owner owner;
    private List<Purchase> purchases = new List<Purchase>();

    public void setName(string name){
        this.name = name;
    }
    
}

namespace Model;
using Interfaces;
using DAO;
using DTO;

public class Store: IValidateDataObject, IDataController<StoreDTO, Store>
{
    private String name;
    private String CNPJ;
    private Owner owner;
    private List<Purchase> purchases = new List<Purchase>();
    public List<StoreDTO> storeDTO = new List<StoreDTO>();

    public Store(Owner owner) { this.owner = owner; }


    


    public static Store convertDTOToModel(StoreDTO obj)
    {
        return new Store(obj.owner);
    }

    public void delete(StoreDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var product = new DAO.Product{
                name = this.name,
                bar_code = this.bar_code,
            };

            context.products.Add(product);

            context.SaveChanges();

            id = product.id;

        }
         return id;
    }

    public void update(StoreDTO obj)
    {

    }

    public StoreDTO findById(int id)
    {

        return new StoreDTO();
    }

    public List<StoreDTO> getAll()
    {        
        return this.StoreDTO;      
    }

   
    public StoreDTO convertModelToDTO()
    {
        var StoreDTO = new StoreDTO();

        StoreDTO.name = this.name;

        StoreDTO.bar_code = this.bar_code;

        return StoreDTO;
    }






    public Boolean validateObject(Store obj)
    {

        if (obj.getName() == null) return false;
        if (obj.getCNPJ() == null) return false;
        if (obj.getOwner() == null) return false;
        if (obj.getPurchases() == null) return false;
        return true;
    }


    public String getName() { return this.name; }
    public void setName(string name) { this.name = name; }

    public String getCNPJ() { return this.CNPJ; }
    public void setCNPJ(String CNPJ) { this.CNPJ = CNPJ; }

    public Owner getOwner() { return this.owner; }


    public List<Purchase> getPurchases() { return purchases; }
    public void addNewPurchase(Purchase purchase)
    { //add list to wishlist
        if (!getPurchases().Contains(purchase))
        { // se a lista nao conter o produto na lusta
            this.purchases.Add(purchase);// adicionar ela na lista
        }
    }


}

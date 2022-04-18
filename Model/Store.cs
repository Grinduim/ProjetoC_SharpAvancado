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
        return new Store(Owner.convertDTOToModel(obj.owner));
    }

    public void delete(StoreDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {

            var owner = new DAO.Owner{

            };

            
            var store = new DAO.Store{
                name = this.name,
                CNPJ = this.CNPJ,
                owner = owner;
            };

            context.stores.Add(store);

            context.SaveChanges();

            id = store.id;

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






    public Boolean validateObject()
    {

        if (this.getName() == null) return false;
        if (this.getCNPJ() == null) return false;
        if (this.getOwner() == null) return false;
        if (this.getPurchases() == null) return false;
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

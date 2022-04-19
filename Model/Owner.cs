namespace Model;
using Interfaces;
using DAO;
using DTO;
public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
{
    private static Owner instance;

    private Guid uuid = Guid.NewGuid();
    public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();
    private Owner(Address address) { this.address = address; }




    public static Owner convertDTOToModel(OwnerDTO obj)
    {
        return new Owner(Address.convertDTOToModel(obj.address));
    }

    public void delete(OwnerDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {

            var address = new DAO.Address{
                street = this.address.getStreet(),
                city = this.address.getCity(),
                state = this.address.getState(),
                country = this.address.getCountry(),
                poste_code = this.address.getPostalCode()
            };
            var owner = new DAO.Owner{
                name = this.name,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                phone = this.phone,
                login = this.login,
                address = address,
                passwd = this.passwd
            };

            context.owners.Add(owner);

            context.SaveChanges();

            id = owner.id;

        }
         return id;
    }

    public void update(OwnerDTO obj)
    {

    }

    public OwnerDTO findById(int id)
    {

        return new OwnerDTO();
    }

    public List<OwnerDTO> getAll()
    {        
        return this.ownerDTO;      
    }

   
    public OwnerDTO convertModelToDTO()
    {
        var ownerDTO = new OwnerDTO();

        ownerDTO.name = this.name;

        ownerDTO.date_of_birth = this.date_of_birth;

        ownerDTO.document = this.document;

        ownerDTO.email = this.email;

        ownerDTO.phone = this.phone;

        ownerDTO.login = this.login;

        ownerDTO.address = this.address.convertModelToDTO();

        ownerDTO.passwd = this.passwd;

    

        return ownerDTO;
    }


    public static Owner getInstance(Address address)
    {
        if (Owner.instance == null)
        {
            Owner.instance = new Owner(address);
        }
        return Owner.instance;
    }

    public Boolean validateObject()
    {
        if (this.getName() == null) return false;
        if (this.getDateOfBirth() == null) return false;
        if (this.getDocument() == null) return false;
        if (this.getEmail() == null) return false;
        if (this.getPhone() == null) return false;
        if (this.getLogin() == null) return false;
        if (this.getAddress().validateObject() == false) return false;
        return true;
    }
}

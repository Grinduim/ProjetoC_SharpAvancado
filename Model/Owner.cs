namespace Model;
using Interfaces;
using DAO;
using DTO;
public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
{
    private static Owner instance;

    private Guid uuid = Guid.NewGuid();
    private Owner(Address address) { this.address = address; }

    public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();


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
        if (this.getAddress().validateObject()==false) return false;
        return true;
    }

    public static Owner convertDTOToModel(OwnerDTO ownerDTO)
    {
        var owner = new Owner(Address.convertDTOToModel(ownerDTO.address));

        owner.name = ownerDTO.name;
        owner.date_of_birth = ownerDTO.date_of_birth;
        owner.document = ownerDTO.document;
        owner.email = ownerDTO.email;
        owner.phone = ownerDTO.phone;
        owner.login = ownerDTO.login;
        owner.passwd = ownerDTO.passwd;
        return owner;
    }

    public void delete(OwnerDTO obj)
    {

    }

    public int save()
    {
        var id = 0;

        using (var context = new DaoContext())
        {

            var address = new DAO.Address{
                street = this.address.getStreet(),
                city = this.address.getCity(),
                state = this.address.getState(),
                country = this.address.getCountry(),
                poste_code = this.address.getPostalCode()
            };
            var client = new DAO.Owner
            {
                name = this.name,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                phone = this.phone,
                passwd = this.passwd,
                login = this.login,
                address = address
            };

            context.owners.Add(client);

            context.SaveChanges();

            id = client.id;

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
        ownerDTO.passwd = this.passwd;
        ownerDTO.address = this.address.convertModelToDTO();
        return ownerDTO;
    }

}

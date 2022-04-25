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
        var owner = new Owner(Address.convertDTOToModel(obj.address));
        owner.name = obj.name;
        owner.date_of_birth = obj.date_of_birth;
        owner.document = obj.document;
        owner.email = obj.email;
        owner.phone = obj.phone;
        owner.login = obj.login;
        owner.passwd = obj.passwd;

        return owner;
    }

    public void delete(OwnerDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {

            // var address = new DAO.Address{
            //     street = this.address.getStreet(),
            //     city = this.address.getCity(),
            //     state = this.address.getState(),
            //     country = this.address.getCountry(),
            //     postal_code = this.address.getPostalCode()
            // };
            // var owner = new DAO.Owner{
            //     name = this.name,
            //     date_of_birth = this.date_of_birth,
            //     document = this.document,
            //     email = this.email,
            //     phone = this.phone,
            //     login = this.login,
            //     address = address,
            //     passwd = this.passwd
            // };

            // context.owners.Add(owner);

            // context.SaveChanges();

            // id = owner.id;

            var address = new DAO.Address{
                street = this.address.getStreet(),
                city = this.address.getCity(),
                state = this.address.getState(),
                country = this.address.getCountry(),
                postal_code = this.address.getPostalCode()
            };
            
            context.addresses.Add(address);

            var owner = new DAO.Owner
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

        Console.WriteLine("entrei no validade");
        //if (this.getName() == null) return false;
       // if (this.getDateOfBirth() == null) return false;
       // if (this.getDocument() == null) return false;
        Console.WriteLine(this.getName());
        if (this.getEmail() == null) return false;
        if (this.getPhone() == null) return false;
        if (this.getLogin() == null) return false;
        if (this.getAddress().validateObject() == false) return false;
        Console.WriteLine("cheguei ao final");
        return true;
    }
}

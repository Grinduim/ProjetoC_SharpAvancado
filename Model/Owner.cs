namespace Model;
using Interfaces;
using DAO;
public class Owner : Person, IValidateDataObject<Owner>
{
    private static Owner instance;

    private Guid uuid = Guid.NewGuid();
    private Owner(Address address) { this.address = address; }


    public static Owner getInstance(Address address)
    {
        if (Owner.instance == null)
        {
            Owner.instance = new Owner(address);
        }
        return Owner.instance;
    }

    public Boolean validateObject(Owner obj)
    {
        if (obj.getName() == null) return false;
        if (obj.getDateOfBirth() == null) return false;
        if (obj.getDocument() == null) return false;
        if (obj.getEmail() == null) return false;
        if (obj.getPhone() == null) return false;
        if (obj.getLogin() == null) return false;
        if (obj.getAddress().validateObject(obj.getAddress()) == false) return false;
        return true;
    }

    public static Owner convertDTOToModel(OwnerDTO ownerDTO)
    {
        var owner = new Owner(Address.convertDTOToModel(ownerDTO.address));

        owner.name = ownerDTO.name;
        owner.date_of_birth = ownerDTO.date_of_birth;
        owner.document= ownerDTO.document;
        owner.email = ownerDTO.email;
        owner.phone = ownerDTO.phone;
        owner.login = ownerDTO.login;
        owner.passwd = ownerDTO.passwd;
        return owner;
    }
}

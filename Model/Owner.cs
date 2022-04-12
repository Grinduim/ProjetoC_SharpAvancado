namespace Model;
using Interfaces;
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
}

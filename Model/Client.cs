namespace Model;
using Interfaces;

public class Client : Person, IValidateDataObject<Client>
{
    private static Client instance;
    private Guid uuid = Guid.NewGuid();
    private Client(Address address) { this.address = address; }

    public static Client getInstance(Address address)
    {
        if (instance == null)
        {
            instance = new Client(address);
        }
        return instance;
    }




    public Boolean validateObject(Client obj)
    {
        if (obj.getName() == null) return false;
        if (obj.getAge() == 0) return false;
        if (obj.getDocument() == null) return false;
        if (obj.getEmail() == null) return false;
        if (obj.getPhone() == null) return false;
        if (obj.getLogin() == null) return false;
        if (obj.getAddress().validateObject(obj.getAddress()) == false) return false;
        return true;
    }
}


namespace Model;

using Interfaces;
using DAO;
using DTO;

public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
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
        if (obj.getDateOfBirth() == null) return false;
        if (obj.getDocument() == null) return false;
        if (obj.getEmail() == null) return false;
        if (obj.getPhone() == null) return false;
        if (obj.getLogin() == null) return false;
        if (obj.getAddress().validateObject(obj.getAddress()) == false) return false;
        return true;
    }

     public static Client convertDTOToModel(ClientDTO clientDTO)
    {
        var client = new client(Address.convertDTOToModel(clientDTO.address));

        client.name = clientDTO.name;
        client.date_of_birth = clientDTO.date_of_birth;
        client.document= clientDTO.document;
        client.email = clientDTO.email;
        client.phone = clientDTO.phone;
        client.login = clientDTO.login;
        client.passwd = clientDTO.passwd;
        return client;
    }

    
}


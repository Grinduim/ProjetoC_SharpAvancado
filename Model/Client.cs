namespace Model;

using Interfaces;
using DAO;
using DTO;

public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
{
    private static Client instance;
    private Guid uuid = Guid.NewGuid();

    public List<ClientDTO> clientDTO = new List<ClientDTO>();
    private Client(Address address) { this.address = address; }

    public static Client getInstance(Address address)
    {
        if (instance == null)
        {
            instance = new Client(address);
        }
        return instance;
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

    public static Client convertDTOToModel(ClientDTO clientDTO)
    {
        var client = new Client(Address.convertDTOToModel(clientDTO.address));

        client.name = clientDTO.name;
        client.date_of_birth = clientDTO.date_of_birth;
        client.document = clientDTO.document;
        client.email = clientDTO.email;
        client.phone = clientDTO.phone;
        client.login = clientDTO.login;
        client.passwd = clientDTO.passwd;
        return client;
    }

    public void delete(ClientDTO obj)
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
                postal_code = this.address.getPostalCode()
            };

            var client = new DAO.Client
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

            context.clients.Add(client);

            context.SaveChanges();

            id = client.id;

        }
        return id;
    }


    public void update(ClientDTO obj)
    {

    }

    public ClientDTO findById(int id)
    {

        return new ClientDTO();
    }

    public List<ClientDTO> getAll()
    {
        return this.clientDTO;
    }
    public ClientDTO convertModelToDTO()
    {
        var clientDTO = new ClientDTO();

        clientDTO.name = this.name;
        clientDTO.name = this.name;
        clientDTO.date_of_birth = this.date_of_birth;
        clientDTO.document = this.document;
        clientDTO.email = this.email;
        clientDTO.phone = this.phone;
        clientDTO.login = this.login;
        clientDTO.passwd = this.passwd;
        clientDTO.address = this.address.convertModelToDTO();
        return clientDTO;
    }
}


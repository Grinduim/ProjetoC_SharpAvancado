namespace Model;

using Interfaces;
using DAO;
using DTO;


public class Address : IValidateDataObject, IDataController<AddressDTO, Address>
{

  
    private String street ;
    private String city ;
    private String state ;
    private String country ;
    private String poste_code ;
    public List<AddressDTO> addressDTO = new List<AddressDTO>();

    public Address(String street, String city, String state, String country, String poste_code)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
        this.poste_code = poste_code;
    }

    public static Address convertDTOToModel(AddressDTO obj)
    {
        return new Address(obj.street, obj.city, obj.state, obj.country, obj.poste_code);
    }

    public void delete(AddressDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var address = new DAO.Address{
                street = this.street,
                city = this.city,
                state = this.state,
                country = this.country,
                poste_code = this.poste_code
            };

            context.addresses.Add(address);

            context.SaveChanges();

            id = address.id;

        }
         return id;
    }

    public void update(AddressDTO obj)
    {

    }

    public AddressDTO findById(int id)
    {

        return new AddressDTO();
    }

    public List<AddressDTO> getAll()
    {        
        return this.addressDTO;      
    }

   
    public AddressDTO convertModelToDTO()
    {
        var addressDTO = new AddressDTO();

        addressDTO.street = this.street;

        addressDTO.state = this.state;

        addressDTO.city = this.city;

        addressDTO.country = this.country;

        addressDTO.poste_code = this.poste_code;

        return addressDTO;
    }

    public Boolean validateObject()
    {

        if (this.getCity() == null) return false;
        if (this.getCountry() == null) return false;
        if (this.getStreet() == null) return false;
        if (this.getState() == null) return false;
        if (this.getPostalCode() == null) return false;
        return true;
    }


    public void setStreet(String street) { this.street = street; }
    public String getStreet() { return this.street; }


    public void setCity(String city) { this.city = city; }
    public String getCity() { return this.city; }


    public void setState(String state) { this.state = state; }
    public String getState() { return this.state; }


    public void setCountry(String country) { this.country = country; }
    public String getCountry() { return this.country; }


    public void setPostalCode(String poste_code) { this.poste_code = poste_code; }
    public String getPostalCode() { return this.poste_code; }

   
}






   

    


namespace Model;
using Interfaces;

public class Address : IValidateDataObject<Address>
{
    private String street = "";
    private String city = "";
    private String state = "";
    private String country = "";
    private String poste_code = "";

    public Address() { }

    public Address(String street, String city, String state, String country, String poste_code)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
        this.poste_code = poste_code;
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

    public Boolean validateObject(Address obj)
    {

        if (obj.getCity() == null) return false;
        if (obj.getCountry() == null) return false;
        if (obj.getStreet() == null) return false;
        if (obj.getState() == null) return false;
        if (obj.getPostalCode() == null) return false;
        return true;
    }
}


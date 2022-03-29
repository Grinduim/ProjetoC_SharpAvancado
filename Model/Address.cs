namespace Model;
public class Address
{
    private String street= "";
    private String city= "";
    private String state= "";
    private String country= "";
    private String poste_code= "";

    public Address(){}

    public void setStreet(String street){this.street = street;}
    public String getStreet(){return this.street;}

    public void setCity( String city){this.city = city;}
    public String getCity(){return this.city;}

    public void setState(String state){this.state = state;}
    public String getState(){return this.state;}

    public void setCountry(String country){this.country = country;}
    public String getCountry(){return this.country;}

    public void  setPosteCode(String poste_code){this.poste_code = poste_code;}
    public String getPosteCode(){return this.poste_code;}
    


}

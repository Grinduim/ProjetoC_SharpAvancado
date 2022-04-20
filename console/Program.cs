using DAO;
using DTO;
using Model;

var id = 0;

            var addressDTO  =  new AddressDTO();

            addressDTO.street = "rua owner 1";

            addressDTO.state = "estado owner 1";

            addressDTO.city  = "cidade owner 1";

            addressDTO.country = "pais owner 1";

            addressDTO.postal_code = "12owner5";


            var ownerDTO = new OwnerDTO();

            ownerDTO.name = "Carlos Ribeiro";

            ownerDTO.email = "carlos.ribeiro@email.com";

            ownerDTO.login = "carlos.ribeiro@email.com";

            ownerDTO.address = addressDTO;

            ownerDTO.passwd = "sdfsdgfgd";

            ownerDTO.phone = "41999999999";
            
            ownerDTO.document = "1252451245";
            
            ownerDTO.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            var ownerModel = Model.Owner.convertDTOToModel(ownerDTO);
            Console.WriteLine(ownerModel.validateObject());
            // if(ownerModel.validateObject()){
            //     id = ownerModel.save();
            //     Console.WriteLine(id);
            // }




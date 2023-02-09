using backend.Entity;
using backend.Models;

namespace backend.Mapping
{

    public class OwnerMapper
    {

        public static OwnerDTO ToOwnerDTOMap(Owner owner)
        {
            if(owner == null){
                return null;
            }

            return new OwnerDTO()
            {
                id = owner.id,
                firstName = owner.first_name,
                lastName = owner.last_name,
                email = owner.email
            };
        }
        public static OwnerDetailDTO ToOwnerDetailDTOMap(Owner owner){

             if(owner == null){
                return null;
            }
            
            return new OwnerDetailDTO(){
                id = owner.id,
                firstName = owner.first_name,
                lastName = owner.last_name,
                email = owner.email
            };
        

        }

        public static Owner OwnerDetailDTOToOwnerMap(OwnerDetailDTO owner){
            if(owner == null){
                return null;
            }

            return new Owner()
            {
                id = owner.id,
                first_name = owner.firstName,
                last_name = owner.lastName,
                email = owner.email
            };
        }

        }
    
    }
using backend.Entity;
using backend.Models;

namespace backend.Mapping
{

    public static class HorseMapper
    {


        private static OwnerDTO getOwner(Horse horse, Dictionary<long, OwnerDTO> owners)
        {
            OwnerDTO owner = null;
            var ownerId = horse.owner_id;
            owner = owners[ownerId];
            return owner;
        }


        /*
        * *params*
        Horse horse -> the horse entity to be mapped, Dict <long, OwnerDTO> owners -> all owners that exist
        * default HorseDTO mapper 
        */
        public static HorseDTO ToHorseDTOMap(Horse horse, Dictionary<long, OwnerDTO> owners)
        {
            if (horse == null)
            {
                return null;
            }

            return new HorseDTO()
            {
                id = horse.id,
                name = horse.name,
                description = horse.description,
                dateOfBirth = horse.date_of_birth,
                sex = horse.sex,
                owner = getOwner(horse, owners)


            };
        }
    }

}
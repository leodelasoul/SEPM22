using backend.Entity;
using backend.Models;
using backend.Enums;
namespace backend.Mapping
{

    public static class HorseMapper
    {


        private static OwnerDTO getOwner(Horse horse, Dictionary<long, OwnerDTO> owners)
        {
            OwnerDTO owner = new OwnerDTO();
            var ownerId = horse.owner_id;
            owner = owners[ownerId];
            return owner;
        }

        private static HorseDTO getHorse(long? id,  List<HorseDTO> horses){
            HorseDTO horseDTO = null;
            foreach(HorseDTO h in horses){
                if(id == h.id){
                    horseDTO = h;
                }
            }
            if(horseDTO == null){
                return null;
            }else {
                return horseDTO;
            }
            
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
            Sex sex = (Sex) Enum.Parse(typeof(Sex), horse.sex); // needed as mssql cant handle enums

            return new HorseDTO()
            {
                id = horse.id,
                name = horse.name,
                description = horse.description,
                dateOfBirth = horse.date_of_birth,
                sex = sex,
                owner = getOwner(horse, owners)


            };
        }

        public static HorseDetailDTO ToHorseDetailDTOMap(Horse horse, Dictionary<long, OwnerDTO> owners,  List<HorseDTO> horses){
            if (horse == null)
            {
                return null;
            }
            Sex sex = (Sex) Enum.Parse(typeof(Sex), horse.sex); // needed as mssql cant handle enums

            return new HorseDetailDTO()
            {
                id = horse.id,
                name = horse.name,
                description = horse.description,
                dateOfBirth = horse.date_of_birth,
                sex = sex,
                owner = getOwner(horse, owners),
                father = getHorse(horse.father, horses),
                mother = getHorse(horse.mother, horses)


            };
        }

        public static Horse HorseDetailDTOToHorseMap(HorseDetailDTO horse){
            return new Horse{
                id = horse.id,
                name = horse.name,
                description = horse.description,
                date_of_birth = horse.dateOfBirth,
                sex = horse.sex.ToString(),
                owner_id = horse.owner.id,
                mother = (horse.mother != null) ? horse.mother.id : null,
                father = (horse.father != null) ? horse.father.id : null
            };
        }

          public static HorseSearchDTO ToHorseSearchDTOMap(Horse horse, Dictionary<long, OwnerDTO> owners)
        {
            if (horse == null)
            {
                return null;
            }
            Sex sex = (Sex) Enum.Parse(typeof(Sex), horse.sex); // needed as mssql cant handle enums

            return new HorseSearchDTO()
            {
                name = horse.name,
                description = horse.description,
                dateOfBirth = horse.date_of_birth,
                sex = sex,
                owner = getOwner(horse, owners)

            };
        }

        

    }

}
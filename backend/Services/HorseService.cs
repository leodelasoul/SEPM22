using backend.Models;
using backend.Entity;
using backend.Mapping;
using System.Linq;
using System.Data.Entity.Infrastructure;
namespace backend.Service{


    public class HorseService : IHorseService
    {

        private readonly WendyDbContext _context;
        private readonly IOwnerService _service;

        public HorseService(WendyDbContext context, IOwnerService service){
            
            _context = context;
            _service = service;

        }


        public HorseDetailDTO create()
        {
            return new HorseDetailDTO();
        }

        public HorseDetailDTO delete(HorseDetailDTO horse)
        {
            return new HorseDetailDTO();
        }

        public List<HorseDTO> getAll()
        {
            Dictionary<long,OwnerDTO> owners = _service.getAll().ToDictionary(o => o.id, o => o);
            List<HorseDTO> horses = new List<HorseDTO>();
            using(var context  = _context){
                // horses = _context.Horse.Select(h => HorseMapper.ToHorseDTOMap(h,owners)).ToList(); // dto mapping for entities
                foreach(Horse horse in context.Horse){
                    horses.Add(HorseMapper.ToHorseDTOMap(horse,owners)); // same as above but suits better for debugging
                }
            }
            return horses;

        }
        /*
            TODO: refactor naive approach, add exception handling
            exposes detailsview of given horse

        */
        public HorseDetailDTO getById(long id)
        {
            HorseDetailDTO horseDetails;
            List<HorseDTO> horsesDTO = new List<HorseDTO>();
            using(var context = _context ){
                
                var owners = context.Owner.ToDictionary(o => o.id, o => OwnerMapper.ToOwnerDTOMap(o));
                var horses = context.Horse.ToList();
                foreach(Horse h in horses){
                    horsesDTO.Add(HorseMapper.ToHorseDTOMap(h,owners));
                }
                horseDetails = HorseMapper.ToHorseDetailDTOMap(context.Horse.Single(h => h.id == id),owners, horsesDTO);
            }

            return horseDetails;
        }

        public HorseDetailDTO update(HorseDetailDTO horse)
        {
            throw new NotImplementedException();
        }
    }
}
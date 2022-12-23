using backend.Models;
using backend.Entity;
using backend.Mapping;
using System.Linq;

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
            List<HorseDTO> horses;
            
            using(var context  = _context){
                 horses = context.Horse.Select(h => HorseMapper.ToHorseDTOMap(h,owners)).ToList(); // dto mapping for entities
                }
            
            return horses;

        }

        public HorseDetailDTO getById(HorseDetailDTO horse)
        {
            throw new NotImplementedException();
        }

        public HorseDetailDTO update(HorseDetailDTO horse)
        {
            throw new NotImplementedException();
        }
    }
}
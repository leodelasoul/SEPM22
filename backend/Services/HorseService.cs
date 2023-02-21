using backend.Models;
using backend.Entity;
using backend.Mapping;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace backend.Service
{


    public class HorseService : IHorseService
    {

        private readonly WendyDbContext _context;
        private readonly IOwnerService _service;

        public HorseService(WendyDbContext context, IOwnerService service)
        {

            _context = context;
            _service = service;

        }
        public HorseDetailDTO create(HorseDetailDTO horse)
        {

            using (var context = _context)
            {
                context.Horse.Add(HorseMapper.HorseDetailDTOToHorseMap(horse));
                context.SaveChanges();
            }
            return horse;
        }

        public void delete(long id)
        {
            using (var context = _context)
            {
                foreach (Horse h in context.Horse)
                {
                    if (h.id == id)
                    {
                        context.Remove(h);
                    }

                }
                context.SaveChanges();


            }
        }


        public HorseDetailDTO delete(long id, HorseDetailDTO horse)
        {
            using (var context = _context)
            {
                foreach (Horse h in context.Horse)
                {
                    if (h.id == id)
                    {
                        context.Remove(h);
                    }

                }
                context.SaveChanges();

                return horse;
            }
        }

        public List<HorseDTO> getAll()
        {
            Dictionary<long, OwnerDTO> owners = _service.getAll().ToDictionary(o => o.id, o => o);
            List<HorseDTO> horses = new List<HorseDTO>();
            using (var context = _context)
            {
                // horses = _context.Horse.Select(h => HorseMapper.ToHorseDTOMap(h,owners)).ToList(); // dto mapping for entities
                foreach (Horse horse in context.Horse)
                {
                    horses.Add(HorseMapper.ToHorseDTOMap(horse, owners)); // same as above but suits better for debugging
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
            using (var context = _context)
            {

                var owners = context.Owner.ToDictionary(o => o.id, o => OwnerMapper.ToOwnerDTOMap(o));
                var horses = context.Horse.ToList();
                foreach (Horse h in horses)
                {
                    horsesDTO.Add(HorseMapper.ToHorseDTOMap(h, owners));
                }
                horseDetails = HorseMapper.ToHorseDetailDTOMap(context.Horse.Single(h => h.id == id), owners, horsesDTO);
            }

            return horseDetails;
        }

        public List<HorseSearchDTO> search(HorseSearchDTO horse)
        {
            List<HorseSearchDTO> foundHorses = new List<HorseSearchDTO>();
            
            using (var context = _context)
            {
                var owners = context.Owner.ToDictionary(o => o.id, o => OwnerMapper.ToOwnerDTOMap(o));
                try
                {
                    var doExist = context.Horse.Where(h => h.name.StartsWith(horse.name) && h.sex.Equals(horse.sex));
                    if (doExist.Count() > 0){
                     foreach(var elem in doExist){
                        foundHorses.Add(HorseMapper.ToHorseSearchDTOMap(elem,owners));
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;

                }

                
            }
            return foundHorses;
        }





        public HorseDetailDTO update(long id, HorseDetailDTO horse)
        {
            Horse toUpdate = new Horse();
            using (var context = _context)
            {
                toUpdate = HorseMapper.HorseDetailDTOToHorseMap(horse);
                var horseEntry = context.Horse.FirstOrDefault(h => h.id == id);
                if (horseEntry != null)
                {
                    PropertyInfo[] horseProperty = typeof(Horse).GetProperties(); // use reflection instead of automapping
                    foreach (PropertyInfo p in horseProperty)
                    {
                        if (p.Name == "id")
                        {
                            continue;
                        }
                        p.SetValue(horseEntry, p.GetValue(toUpdate, null), null);
                    }
                }



                context.SaveChanges();
            }
            return horse;
        }
    }
}
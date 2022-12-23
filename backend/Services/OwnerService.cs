using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Entity;
using backend.Enums;
using backend.Mapping;

namespace backend.Service{

    public class OwnerService : IOwnerService
    {
        private readonly WendyDbContext _context;

        public OwnerService(WendyDbContext context){
            _context = context;
        }

        public OwnerDTO create()
        {
            return new OwnerDTO();
        }

        public OwnerDTO delete(OwnerDTO owner)
        {
            return new OwnerDTO();

        }

        public List<OwnerDTO> getAll()
        {
            List<OwnerDTO> owners;
            using(var context  = _context){
                 owners = context.Owner.Select(o => OwnerMapper.ToOwnerDTOMap(o)).ToList(); // dto mapping for entities
                }
            
            return owners;

        }

        public OwnerDTO getById(OwnerDTO owner)
        {
                        return new OwnerDTO();

        }

        public OwnerDTO update(OwnerDTO owner)
        {
            return new OwnerDTO();
        }

        public List<OwnerDTO> search(OwnerDTO searchParameters){
            return new List<OwnerDTO>();

        }


    }

}
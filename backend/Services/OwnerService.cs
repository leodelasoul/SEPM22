using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Entity;
using backend.Enums;
using backend.Mapping;

namespace backend.Service
{

    public class OwnerService : IOwnerService
    {
        private readonly WendyDbContext _context;

        public OwnerService(WendyDbContext context)
        {
            _context = context;
        }

        public OwnerDetailDTO create()
        {
            return new OwnerDetailDTO();
        }

        public OwnerDetailDTO delete(OwnerDTO owner)
        {
            return new OwnerDetailDTO();

        }

        public List<OwnerDTO> getAll()
        {
            List<OwnerDTO> owners;
            using (var context = _context)
            {
                owners = context.Owner.Select(o => OwnerMapper.ToOwnerDTOMap(o)).ToList(); // dto mapping for entities
            }

            return owners;

        }

        public OwnerDetailDTO getById(long id)
        {
            OwnerDetailDTO owner = new OwnerDetailDTO();
            using (var context = _context)
            {
                foreach (Owner o in context.Owner)
                {
                    if (o.id == id)
                    {
                        owner = OwnerMapper.ToOwnerDetailDTOMap(o);
                    }
                }
            }

            return owner;

        }

        public OwnerDetailDTO update(OwnerDTO owner)
        {
            return new OwnerDetailDTO();
        }

        public List<OwnerDTO> search(OwnerDTO searchParameters)
        {
            return new List<OwnerDTO>();

        }


    }

}
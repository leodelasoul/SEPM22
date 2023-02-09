using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Entity;
using backend.Enums;
using backend.Mapping;
using System.Reflection;

namespace backend.Service
{

    public class OwnerService : IOwnerService
    {
        private readonly WendyDbContext _context;

        public OwnerService(WendyDbContext context)
        {
            _context = context;
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



        public List<OwnerDTO> search(string searchParameters)
        {

            List<OwnerDTO> foundOwners = new List<OwnerDTO>();
            using (var context = _context)
            {
                try
                {
                    var doExist = context.Owner.Where(h => h.first_name.Contains(searchParameters) || h.last_name.Contains(searchParameters));
                    if (doExist.Count() > 0)
                    {
                        foreach (var elem in doExist)
                        {
                            foundOwners.Add(OwnerMapper.ToOwnerDTOMap(elem));
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;

                }


            }
            return foundOwners;
        }

        public OwnerDetailDTO update(long id, OwnerDetailDTO owner)
        {
            Owner toUpdate = new Owner();
            toUpdate = OwnerMapper.OwnerDetailDTOToOwnerMap(owner);

            using (var context = _context)
            {
                var ownerEntry = context.Owner.FirstOrDefault(o => o.id == id);
                if (ownerEntry != null)
                {
                    PropertyInfo[] ownerProperty = typeof(Owner).GetProperties(); // use reflection instead of automapping
                    foreach (PropertyInfo p in ownerProperty)
                    {
                        if (p.Name == "id")
                        {
                            continue;
                        }
                        p.SetValue(ownerEntry, p.GetValue(toUpdate, null), null);
                    }
                    context.SaveChanges();

                }
            }
            return owner;

        }

        public OwnerDetailDTO delete(OwnerDetailDTO owner)
        {
            using (var context = _context)
            {
                foreach (Owner o in context.Owner)
                {
                    if (owner.id == o.id)
                    {
                        context.Remove(o);

                    }
                }
                context.SaveChanges();
            }

            return owner;
        }

        public OwnerDetailDTO create(OwnerDetailDTO owner)
        {
            using (var context = _context)
            {
                context.Owner.Add(OwnerMapper.OwnerDetailDTOToOwnerMap(owner));
                context.SaveChanges();
            }

            return owner;
        }
    }

}
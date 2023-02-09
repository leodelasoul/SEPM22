using backend.Models;
using backend.Entity;

namespace backend.Service {


    public interface IOwnerService{

        OwnerDetailDTO update(long id,OwnerDetailDTO owner);
        OwnerDetailDTO delete(OwnerDetailDTO owner);
        OwnerDetailDTO create(OwnerDetailDTO owner);
        List<OwnerDTO> getAll();
        OwnerDetailDTO getById(long id);

        List<OwnerDTO> search(string searchParameters);





    }

}
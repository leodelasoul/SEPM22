using backend.Models;
using backend.Entity;

namespace backend.Service {


    public interface IOwnerService{

        OwnerDetailDTO update(OwnerDTO owner);
        OwnerDetailDTO delete(OwnerDTO owner);
        OwnerDetailDTO create();
        List<OwnerDTO> getAll();
        OwnerDetailDTO getById(long id);

        List<OwnerDTO> search(OwnerDTO searchParameters);





    }

}
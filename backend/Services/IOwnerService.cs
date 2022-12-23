using backend.Models;
using backend.Entity;

namespace backend.Service {


    public interface IOwnerService{

        OwnerDTO update(OwnerDTO owner);
        OwnerDTO delete(OwnerDTO owner);
        OwnerDTO create();
        List<OwnerDTO> getAll();
        OwnerDTO getById(OwnerDTO owner);

        List<OwnerDTO> search(OwnerDTO searchParameters);





    }

}
using backend.Models;


namespace backend.Service {


    public interface IHorseService{

        HorseDetailDTO update(long id, HorseDetailDTO horse);
        void delete(long id);

        HorseDetailDTO delete(long id, HorseDetailDTO horse);

        HorseDetailDTO create(HorseDetailDTO horse);
        List<HorseDTO> getAll();
        HorseDetailDTO getById(long id);


        List<HorseSearchDTO> search(string searchText);


        


    }

}
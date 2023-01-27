using backend.Models;


namespace backend.Service {


    public interface IHorseService{

        HorseDetailDTO update(HorseDetailDTO horse);
        HorseDetailDTO delete(HorseDetailDTO horse);
        HorseDetailDTO create();
        List<HorseDTO> getAll();
        HorseDetailDTO getById(long id);


    }

}
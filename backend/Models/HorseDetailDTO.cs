using backend.Enums;
using backend.Entity;

namespace backend.Models {

public class HorseDetailDTO {


    public long id{get;set;}


    public String name {get;set;}
    public String description{get;set;}

    public DateTime dateOfBirth{get;set;}

    public Sex sex{get;set;}

    public OwnerDTO owner{get;set;}

    public Horse mother{get;set;}
    public Horse father{get;set;}



}

}
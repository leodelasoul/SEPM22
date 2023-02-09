using backend.Enums;
using backend.Entity;

namespace backend.Models {

public class HorseSearchDTO{
    public String name {get;set;}
    public String description{get;set;}

    public DateTime dateOfBirth{get;set;}

    public Sex sex{get;set;}

    public OwnerDTO owner{get;set;}



}

}
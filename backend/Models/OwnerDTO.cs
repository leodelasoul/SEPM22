using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend.Entity;




namespace backend.Models {

public class OwnerDTO{


    public long id {get;set;}
    public String firstName {get;set;}
    public String lastName{get;set;}

    public String email{get;set;}


}



}
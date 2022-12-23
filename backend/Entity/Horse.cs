using System;
using backend.Enums;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace backend.Entity
{
public class Horse {
    public long id{get; set;}
    public String name{get;set;}
    public String description{get;set;}
    public DateTime date_of_birth{get;set;}
    public Sex sex{get;set;}
    public long owner_id{get;set;}

    public long father;

    public long mother;




        

  }
    
}


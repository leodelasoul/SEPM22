namespace backend.Entity{
    public class Owner {

        public long id {get;set;}
        public String first_name{get;set;}
        public String last_name{get;set;}
        public String email{get;set;}


        public override String ToString(){
            return "Owner{"
                    + "id=" + id
                    + ", firstName='" + first_name + '\''
                    + ", lastName='" + last_name + '\''
                    + ", email='" + email + '\''
                    + '}';
        }
        

    }
}
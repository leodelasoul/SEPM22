using System.Text.Json.Serialization;
namespace backend.Enums{
    
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Sex{
    FEMALE,
    MALE

}
}
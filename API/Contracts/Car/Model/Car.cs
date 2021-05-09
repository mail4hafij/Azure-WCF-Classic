using System.Runtime.Serialization;

namespace API.Contracts.Car.Model
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public string Color { get; set; }
    }
}
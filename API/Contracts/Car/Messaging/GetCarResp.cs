using System.Runtime.Serialization;

namespace API.Contracts.Car.Messaging
{
    [DataContract]
    public class GetCarResp : Resp
    {
        [DataMember]
        public Model.Car Car { get; set; }
    }
}

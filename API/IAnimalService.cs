using API.Contracts.Animals.Messaging;
using API.Contracts.Car.Messaging;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using API.Contracts.Tiger.Messaging;
using System.ServiceModel;

namespace API
{
    [ServiceContract]
    public interface IAnimalService
    {
        [OperationContract]
        GetCatResp GetCat(GetCatReq req);

        [OperationContract]
        GetDogResp GetDog(GetDogReq req);

        [OperationContract]
        GetTigerResp GetTiger(GetTigerReq req);

        [OperationContract]
        AddAnimalsResp AddAnimals(AddAnimalsReq req);

        [OperationContract]
        GetCarResp GetCar(GetCarReq req);
    }
}

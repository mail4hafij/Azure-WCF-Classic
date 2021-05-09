using API;
using API.Contracts.Animals.Messaging;
using API.Contracts.Car.Messaging;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using API.Contracts.Tiger.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFWEB
{
    public class AnimalService : IAnimalService
    {
        public GetCatResp GetCat(GetCatReq req)
        {
            return new GetCatResp() { Cat = new API.Contracts.Cat.Model.Cat() { Color = "Hello" } };
        }

        public GetDogResp GetDog(GetDogReq req)
        {
            return new GetDogResp() { Dog = new API.Contracts.Dog.Model.Dog() { Color = "World" } };
        }

        public GetTigerResp GetTiger(GetTigerReq req)
        {
            return new GetTigerResp() { Tiger = new API.Contracts.Tiger.Model.Tiger() { Color = "Lipsum" } };
        }

        public AddAnimalsResp AddAnimals(AddAnimalsReq req)
        {
            return new AddAnimalsResp();
        }

        public GetCarResp GetCar(GetCarReq req)
        {
            return new GetCarResp() { Car = new API.Contracts.Car.Model.Car() { Color = "Toyota" } };
        }
    }
}

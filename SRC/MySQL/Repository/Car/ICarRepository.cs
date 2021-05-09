using System.Collections.Generic;

namespace SRC.MySQL.Repository.Car
{
    public interface ICarRepository
    {
        List<SRC.MySQL.Data.Model.Car> LoadAll();
        void Add(SRC.MySQL.Data.Model.Car car);
    }
}

namespace SRC.MySQL.Data.Mapper
{
    public class CarMapper : ICarMapper
    {
        public API.Contracts.Car.Model.Car Map(SRC.MySQL.Data.Model.Car car)
        {
            return new API.Contracts.Car.Model.Car
            {
                Color = car.Color
            };
        }
    }
}


namespace SRC.MySQL.Data.Mapper
{
    public interface ICarMapper
    {
        API.Contracts.Car.Model.Car Map(SRC.MySQL.Data.Model.Car car);
    }
}

using System.Collections.Generic;
using System.Linq;
using SRC.LIB;

namespace SRC.MySQL.Repository.Car
{
    public class CarRepository : MySQLBaseRepository, ICarRepository
    {
        public CarRepository(IMySQLUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<SRC.MySQL.Data.Model.Car> LoadAll()
        {
            return _unitOfWork.Context.Cars.OrderByDescending(c => c.CarId).ToList<Data.Model.Car>();
        }

        public void Add(SRC.MySQL.Data.Model.Car car)
        {
            _unitOfWork.Context.Cars.Add(car);
        }
    }
}

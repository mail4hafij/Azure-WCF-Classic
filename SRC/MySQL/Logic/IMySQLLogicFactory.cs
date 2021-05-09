using SRC.MySQL.Logic.Car;

namespace SRC.MySQL.Logic
{
    public interface IMySQLLogicFactory
    {
        ICarLogic CreateCarLogic(IMySQLUnitOfWork unitOfWork);
    }
}
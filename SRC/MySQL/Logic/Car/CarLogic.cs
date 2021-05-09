using SRC.MySQL.Repository;

namespace SRC.MySQL.Logic.Car
{
    public class CarLogic : MySQLBaseLogic, ICarLogic
    {
        private readonly IMySQLRepositoryFactory _repositoryFactory;

        public CarLogic(IMySQLUnitOfWork unitOfWork, IMySQLRepositoryFactory reporepositoryFactory) : base(unitOfWork)
        {
            _repositoryFactory = reporepositoryFactory;
        }
    }
}

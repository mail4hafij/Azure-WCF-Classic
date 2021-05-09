using SRC.MySQL.Repository.Car;

namespace SRC.MySQL.Repository
{
    public interface IMySQLRepositoryFactory
    {
        // NOTE: the IUnitOfWork parameter *must* be named 'unitOfWork', otherwise the IoC factory creation won't work
        // see https://github.com/ninject/Ninject.Extensions.Factory/wiki/Factory-interface
        ICarRepository CreateCarRepository(IMySQLUnitOfWork unitOfWork);
    }
}
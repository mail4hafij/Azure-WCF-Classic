using SRC.MySQL.Data.Mapper;


namespace SRC.MySQL.Data
{
    public interface IMySQLMapperFactory
    {
        ICarMapper CreateCarMapper(IMySQLUnitOfWork unitOfWork);
    }
}

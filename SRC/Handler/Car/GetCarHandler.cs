using API.Contracts.Car.Messaging;
using API.Contracts.Cat.Messaging;
using SRC.HelloWorld;
using SRC.HelloWorld.Data;
using SRC.HelloWorld.Repository;
using SRC.LIB;
using SRC.MySQL.Data;
using SRC.MySQL.Repository;

namespace SRC.Handler.Car
{
    public class GetCarHandler : RequestHandler<GetCarReq, GetCarResp>
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMySQLRepositoryFactory _repositoryFactory;
        private readonly IMySQLMapperFactory _mapperFactory;

        public GetCarHandler(IUnitOfWorkFactory unitOfWorkFactory, IMySQLRepositoryFactory repositoryFactory, IMySQLMapperFactory mapperFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;
            _mapperFactory = mapperFactory;
        }
        public override GetCarResp Process(GetCarReq req)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateAndBeginTransactionForMySQL(false))
            {
                var carList = _repositoryFactory.CreateCarRepository(unitOfWork).LoadAll();
                return new GetCarResp { Car = _mapperFactory.CreateCarMapper(unitOfWork).Map(carList[0])};   
            }
        }
    }
}

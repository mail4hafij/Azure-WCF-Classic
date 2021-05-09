using API.Contracts.Animals.Messaging;
using SRC.HelloWorld.Logic;
using SRC.LIB;

namespace SRC.Handler.Animal
{
    public class AddAnimalsHandler : RequestHandler<AddAnimalsReq, AddAnimalsResp>
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IHelloWorldLogicFactory _logicFactory;

        public AddAnimalsHandler(IUnitOfWorkFactory unitOfWorkFactory, IHelloWorldLogicFactory logicFactory)
        {
            // Here we should inject unitOfWork or dbContext
            // If needed, then inject the logic factory.
            _unitOfWorkFactory = unitOfWorkFactory;
            _logicFactory = logicFactory;
        }
        public override AddAnimalsResp Process(AddAnimalsReq req)
        {
            // A handler should map to Response object (AddAnimalsResp)
            // If needed here we can open a unit of work (Optional) or dbContext transaction.
            using (var unitOfWork = _unitOfWorkFactory.CreateAndBeginTransactionForHelloWorld(false))
            {
                // Get the logic class given the unitOfWork or DbContext created/opened here.
                var animalLogic = _logicFactory.CreateAnimalLogic(unitOfWork);
                animalLogic.AddAnimals(req.CatColor, req.DogColor);

                unitOfWork.Commit();
                return new AddAnimalsResp();
            }
        }
    }
}
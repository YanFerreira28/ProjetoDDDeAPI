using SISControler.Domain.Contracts.Repositories;
using SISControler.Domain.Entities;

namespace SISControler.Domain.Services
{
   public class ServiceProduto : ServiceBase<Produto>
    {
        #region[Propriedade]

        public readonly IRepositoryProduct _sisRepository;

        #endregion

        #region[Construtor]

        public ServiceProduto(IRepositoryProduct sisRepository) : base(sisRepository)
        {
            _sisRepository = sisRepository;
        }

        #endregion

    }
}

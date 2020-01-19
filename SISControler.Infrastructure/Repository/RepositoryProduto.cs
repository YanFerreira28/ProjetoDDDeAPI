using SISControler.Domain.Contracts.Repositories;
using SISControler.Domain.Entities;
using SISControler.Infrastructure.Data;

namespace SISControler.Infrastructure.Repository
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduct
    {
        #region[Parametros]

        public readonly DataContext _sisContext;

        #endregion

        #region[Construtor]

        public RepositoryProduto(DataContext sisContext):base(sisContext)
        {
            _sisContext = sisContext;
        }

        #endregion
    }
}

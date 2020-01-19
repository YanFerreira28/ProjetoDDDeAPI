using SISControler.Domain.ValueObjects;
using System;

namespace SISControler.Domain.Entities
{
    public class Produto
    {

        #region[Parametros]

        public int id { get; set; }
        public string nomeProduto { get; set; }
        public string fornecedor { get;  set; }
        public string marca { get;  set; }
        public decimal valor { get; set; }
        public virtual Cliente Cliente { get; set; }

        #endregion


        #region[Metodos]

        public static void isValidProd(string produto)
        {
            if (string.IsNullOrEmpty(produto))
            {
                throw new ArgumentNullException(produto, "verifique o parametro Produto");
            }
        }

        public static void isValidFornecedor(string fornecedor)
        {
            if (string.IsNullOrEmpty(fornecedor))
            {
                throw new ArgumentNullException(fornecedor, "verifique o parametro Fornecedor");
            }
        }

        public static void isValidMarca(string marca)
        {
            if (string.IsNullOrEmpty(marca))
            {
                throw new ArgumentNullException(marca, "verifique o parametro Produto");
            }
        }

        public static void isValidValor(decimal valor)
        {
            if (valor < 0)
            {
                throw new ArgumentNullException();
            }
        }

        #endregion

    }
}

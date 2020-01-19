using SISControler.Domain.ValueObjects;
using System;

namespace SISControler.Domain.Entities
{
    public class Usuario
    {
        #region[Parametros]

        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }

        #endregion

        #region[Construtores]

        public Usuario(string Nome, string Senha)
        {
            Validation(Nome, Senha);
            nome = Nome;
            senha = Senha;
        }

        #endregion

        #region[Metodos]

        public static void Validation(string nome, string senha)
        {
            if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(senha))
            {
                throw new ArgumentNullException(nome, "Verifique o parametro Nome");
            }
        }

        #endregion

    }
}

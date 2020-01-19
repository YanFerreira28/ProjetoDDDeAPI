using SISControler.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SISControler.Domain.Entities
{
    public class Cliente
    {
        #region[Parametros]

        public int id { get; set; }
        public string nomeCliente { get; set; }
        public string sobrenome { get; set; }
        public string idade { get; set; }
        public ICollection<Produto> Produto { get; set; }

        #endregion

        #region[Contrutores]

        public Cliente(string nomecli, string Sobrenome, string Idade)
        {
            IsValidIdade(Idade);
            IsValidNome(nomecli);
            IsValidSobrenome(Sobrenome);
            nomeCliente = nomecli;
            sobrenome = Sobrenome;
            idade = Idade;
        }

        #endregion

        #region[Métodos]

        public static void IsValidNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException(nome, "verifique o parametro nome");
        }

        public static void IsValidSobrenome(string sobrenome)
        {
            if (string.IsNullOrEmpty(sobrenome))
                throw new ArgumentNullException(sobrenome, "verifique o parametro sobrenome");
        }

        public static void IsValidIdade(string idade)
        {
            if (string.IsNullOrEmpty(idade))
                throw new ArgumentNullException(idade, "verifique o parametro idade");
        }

        #endregion

    }
}

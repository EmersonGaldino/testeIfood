using System;
using System.Collections.Generic;
using System.Linq;

namespace ifood.test.galdino.domain.Utils.Exceptions
{
    public class MessageException : Exception
    {
        public readonly List<string> Erros;

        public MessageException()
            : base()
        {
            Erros = new List<string>();
        }

        public MessageException(params string[] erros)
            : this(new List<string>(erros))
        { }

        public MessageException(IEnumerable<string> erros)
        {
            Erros = new List<string>();
            Erros.AddRange(erros);
        }

        public MessageException(string erro, Exception ex)
            : base(erro, ex)
        {
            Erros = new List<string>();
            Erros.Add(erro);
        }

        public string GetMessages(string separador = " ") =>
            string.Join(separador, Erros.Select(e => e));
    }
}

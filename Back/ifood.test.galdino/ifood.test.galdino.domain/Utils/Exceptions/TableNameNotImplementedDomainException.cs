using System.Runtime.Serialization;

namespace ifood.test.galdino.domain.Utils.Exceptions
{
    public class TableNameNotImplementedDomainException : System.Exception
    {
        #region Methods
        public TableNameNotImplementedDomainException(string message) : base(message) { }
        public TableNameNotImplementedDomainException() : base() { }
        private TableNameNotImplementedDomainException(SerializationInfo info, StreamingContext context) { }
        #endregion
    }
}

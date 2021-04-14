using System.Collections.Generic;

namespace ifood.test.galdino.domain.Utils.Exceptions
{
    public sealed class BadResponse 
    {
     
        public List<string> Errors { get; private set; }
    }
}

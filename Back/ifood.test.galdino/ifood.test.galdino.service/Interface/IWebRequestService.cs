using System.Collections.Generic;
using System.Threading.Tasks;
using ifood.test.galdino.domain.Utils.Enum;

namespace ifood.test.galdino.service.Interface
{
    public interface IWebRequestService
    {
        Task<T> RequestJsonSerialize<T>(
            string url,
            object jsonData,
            ETypeMethod method,
            string token = null,
            List<KeyValuePair<string, string>> parameters = null,
            IEnumerable<KeyValuePair<string, string>> valuePairs = null) where T : class;
    }
}

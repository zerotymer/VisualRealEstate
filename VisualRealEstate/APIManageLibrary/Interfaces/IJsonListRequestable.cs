using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIQueryLibrary.Interfaces
{
    /// <summary>
    /// List를 반환할 수 있는 메서드를 포함합니다.
    /// </summary>
    public interface IJsonListRequestable<TResult>
    {
        List<TResult> GetJsonListRequest();
        Task<List<TResult>> GetJsonListRequestAsync();
    }
}

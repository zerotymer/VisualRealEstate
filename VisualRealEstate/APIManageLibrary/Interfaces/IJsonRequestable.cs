using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIQueryLibrary.Interfaces
{
    /// <summary>
    /// JSON 요청을 처리할 수 있는 메서드를 포함합니다.
    /// </summary>
    /// <typeparam name="TResult">반환값</typeparam>
    public interface IJsonRequestable<TResult> where TResult : IJsonResponsible
    {
        TResult GetJsonRequest();
        Task<TResult> GetJsonRequestAsync();
    }
}

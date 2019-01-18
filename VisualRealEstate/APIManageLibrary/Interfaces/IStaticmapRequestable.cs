using System.Threading.Tasks;
using System.Windows.Media;

namespace APIQueryLibrary.Interfaces
{
    /// <summary>
    /// 정적인 이미지를 반환할 수 있는 메서드를 포함합니다.
    /// </summary>
    public interface IStaticMapRequestable
    {
        ImageSource GetStaticMapRequest();
        Task<ImageSource> GetStaticMapRequestAsync();
    }
}

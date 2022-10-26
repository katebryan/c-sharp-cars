using System.Threading.Tasks;

namespace cSharpcars
{
    public interface IApi
    {
        Task<string> getApiResponse();
    }
}
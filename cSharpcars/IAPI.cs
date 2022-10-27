using System.Threading.Tasks;

namespace cSharpcars
{
    public interface IApi
    {
        string getParking();
        Task<string> getApiResponse(string endpoint);
    }
}
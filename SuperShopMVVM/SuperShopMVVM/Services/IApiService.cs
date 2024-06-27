using System.Threading.Tasks;
using SuperShopMVVM.Models;


namespace SuperShopMVVM.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}

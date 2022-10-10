using RestSharp;
using RestSharp.Serializers.Json;
using Vk_Project.Constants;

namespace Vk_Project.Services
{
    public abstract class BaseService
    {
        protected readonly RestClient RestClient;

        protected BaseService()
        {
            RestClient = new RestClient(Constant.BaseUrl);
            RestClient.UseSerializer(() => new SystemTextJsonSerializer());
        }
    }
}
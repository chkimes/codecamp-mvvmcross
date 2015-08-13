using System.Threading.Tasks;

namespace MvvmCross.Demo.Core
{
    public interface IHttpClient
    {
        Task<string> Request(string url);
    }
}
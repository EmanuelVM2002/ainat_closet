using ainat_closet.Common;
using ainat_closet.Models;

namespace ainat_closet.Helpers
{
    public interface IOrdersHelper
    {
        Task<Response> ProcessOrderAsync(ShowCartViewModel model);
        Task<Response> CancelOrderAsync(int id);
    }
}

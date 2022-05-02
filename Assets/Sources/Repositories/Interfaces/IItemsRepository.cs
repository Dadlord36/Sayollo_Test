using System.Threading.Tasks;
using Models.JSON;

namespace Repositories.Interfaces
{
    public interface IItemsRepository
    {
        Task<ProductResponseModel> GetPresentItem();
        Task<UserActionResponseModel> SubmitUserInfo(in UserInfoModel userInfoModel);
    }
}
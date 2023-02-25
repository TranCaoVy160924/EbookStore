using EbookStore.Contract.ViewModel.Pagination;

namespace EbookStore.Contract.ViewModel.User.Request;
public class UserQueryRequest : QueryStringParameters
{
    public string UserName { get; set; } = "";
}

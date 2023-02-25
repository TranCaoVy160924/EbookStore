using EbookStore.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.UserRepo;
public static class UserQueryExtendsion
{
    public static IQueryable<User> QueryUserName(this IQueryable<User> query, string username)
    {
        return query.Where(x => x.UserName.Equals(username));
    }
}

using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Mapper;

public class MapperProfile: Profile
{
    public MapperProfile() 
    {
        CreateMap<User, UserRegisterResponse>();
    }
}

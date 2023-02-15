using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
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
        #region User
        CreateMap<User, UserRegisterResponse>();
        CreateMap<UserRegisterRequest, User>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.SecurityStamp, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
        #endregion


        #region Book
        CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId));
        #endregion
    }
}

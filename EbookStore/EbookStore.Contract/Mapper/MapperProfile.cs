using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.Genre.Response;
using EbookStore.Contract.ViewModel.Sale.Response;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Contract.ViewModel.LibraryItem.Request;
using EbookStore.Contract.ViewModel.LibraryItem.Response;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Contract.ViewModel.User.Response;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Contract.Mapper;

public class MapperProfile : Profile
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
        CreateMap<User, UserQueryResponse>();
        #endregion

        #region Book
        CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId))
            .ForMember(dest => dest.SalePercent, opt => opt.MapFrom(
                src => (src.Sale != null && DateTime.Compare(src.Sale.EndDate, DateTime.Today) > 0) ? src.Sale.SalePercent : 0));
        CreateMap<BookCreateRequest, Book>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
        CreateMap<Book, BookDetailResponse>()
            .ForMember(dest => dest.SalePercent, opt => opt.MapFrom(
                src => (src.Sale != null && DateTime.Compare(src.Sale.EndDate, DateTime.Today) > 0) ? src.Sale.SalePercent : 0));
        #endregion

        #region Sale
        CreateMap<SaleCreateRequest, Sale>();
        CreateMap<Sale, SaleResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SaleId));
        #endregion

        #region Genre
        CreateMap<Genre, GenreResponse>();
        #endregion

        #region Sale
        CreateMap<Sale, SaleDetailResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SaleId))
            .ForMember(dest => dest.OnSaleBookIds, opt =>
            opt.MapFrom(src => src.Books.Select(b => b.BookId).ToList()));
        #endregion

        #region Library
        CreateMap<Book, LibraryItemResponse>();
        #endregion
    }
}

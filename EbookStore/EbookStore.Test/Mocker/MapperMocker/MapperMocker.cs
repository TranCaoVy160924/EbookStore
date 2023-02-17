using AutoMapper;
using EbookStore.Contract.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Test.Mocker.MapperMocker;

public static class MapperMocker
{
    public static IMapper CreateMapper()
        => new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile())).CreateMapper();
}

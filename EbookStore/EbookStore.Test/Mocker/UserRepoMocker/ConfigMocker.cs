using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Test.Mocker.UserRepoMocker;

public static class ConfigMocker
{
    public static IConfiguration CreateConfig(MockRepository mockRepository)
    {
        var inMemorySettings = new Dictionary<string, string> {
            {"JwtSettings:key", "0123456789ABCDEF"},
            {"JwtSettings:validIssuer", "0123456789ABCDEF"},
            {"JwtSettings:validAudience", "0123456789ABCDEF"},
            {"JwtSettings:expires", "144"}
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build(); ;
    }
}

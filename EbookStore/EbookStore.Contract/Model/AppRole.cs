using Microsoft.AspNetCore.Identity;
using System;


namespace EbookStore.Contract.Model;

public class AppRole : IdentityRole<Guid>
{
    public string Description { get; set; }
}

﻿using Microsoft.AspNetCore.Identity;

namespace lab13.Models;

public class ApplicationUser : IdentityUser
{
    public required string FullName { get; set; }
}

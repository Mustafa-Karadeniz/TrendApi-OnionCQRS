﻿

using TrendApi.Application.Base;

namespace TrendApi.Application.Features.Auth.Exceptions;

public class EmailAddressShouldBeValidException : BaseExceptions
{
    public EmailAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır.") { }
}
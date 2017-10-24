using System;
using BookingLibrary.Service.Identity.Domain.DataAccessors;
using BookingLibrary.Service.Identity.Domain.ViewModels;
using BookingLibrary.Service.Identity.DTOs;
using BookingLibrary.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using BookingLibrary.Service.Identity.Domain;

namespace BookingLibrary.Service.Identity
{
    [Route("api/identities")]
    public class IdentityController : Controller
    {
        private IIdentityReportDataAccessor _dataAccessor = null;
        private IPasswordHasher _passwordHasher = null;

        public IdentityController(IIdentityReportDataAccessor dataAccessor, IPasswordHasher passwordHasher)
        {
            _dataAccessor = dataAccessor;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public IdentityViewModel GetIdentity(IdentityDTO dto)
        {
            if (_passwordHasher == null)
            {
                throw new Exception("The password hasher is not initialized.");
            }

            return _dataAccessor.GetIdentity(dto.UserName, dto.Password);
        }
    }
}

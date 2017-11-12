using System;
using BookingLibrary.Service.Identity.Domain.DataAccessors;
using BookingLibrary.Service.Identity.Domain.ViewModels;
using BookingLibrary.Service.Identity.DTOs;
using BookingLibrary.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using BookingLibrary.Service.Identity.Domain;
using BookingLibrary.Infrastructure.InjectionFramework;
using System.Collections.Generic;

namespace BookingLibrary.Service.Identity
{
    [Route("api/identities")]
    public class IdentityController : Controller
    {
        private IIdentityReportDataAccessor _dataAccessor = null;
        private IPasswordHasher _passwordHasher = null;

        public IdentityController()
        {
            _dataAccessor = InjectContainer.GetInstance<IIdentityReportDataAccessor>();
            _passwordHasher = InjectContainer.GetInstance<IPasswordHasher>();
        }

        [Route("")]
        [HttpPost]
        public IdentityViewModel GetIdentity(IdentityDTO dto)
        {
            if (_passwordHasher == null)
            {
                throw new Exception("The password hasher is not initialized.");
            }

            return _dataAccessor.GetIdentity(dto.UserName, dto.Password);
        }

        [HttpGet("~/api/customers")]
        public List<CustomerListViewModel> GetCustomers()
        {
            return _dataAccessor.GetCustomerList();
        }

        [HttpGet("~/api/customers/{customerId}")]
        public CustomerListViewModel GetCustomerDetails(Guid customerId)
        {
            return _dataAccessor.GetCustomerSingleListViewModel(customerId);
        }

        [HttpGet("~/api/accounts/{accountId}")]
        public IdentityDetailsViewModel GetAccount(Guid accountId)
        {
            return _dataAccessor.GetAccountDetails(accountId);
        }
    }
}

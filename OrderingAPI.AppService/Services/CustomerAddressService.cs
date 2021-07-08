
using OrderingAPI.Models.DTO;
using OrderingAPI.Repository.EFObjects;
using OrderingAPI.Repository.Interfaces;
using OrderingAPI.Repository.LocalRepoistory;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.AppService.Services
{
   public class CustomerAddressService
    {
        private readonly IUnitOfWork<Address> _customeraddressreposotory;
       /// private readonly IRepository<Address> _customeraddressreposotory;
        public CustomerAddressService(IUnitOfWork<Address> customeraddressreposotory)
        {

            _customeraddressreposotory = customeraddressreposotory;

        }

        public List<rCustomerAddressCTO> getaddressinfo(int fkid)
        {
            try
            {
                List<rCustomerAddressCTO> formattedlist = new List<rCustomerAddressCTO>();
                List<Address> addresses  = _customeraddressreposotory._repository.getObjects(fkid);

                foreach (Address add in addresses)
                {
                    formattedlist.Add(new rCustomerAddressCTO(add.AddressID,add.CustomerID,add.AddressTypeID,add.Address1,add.Address2,add.Town,add.Postcode));
                }

                return formattedlist;
   
            }
            catch (Exception ex)
            {
                //_errorLogger.Log(ex);
                return null;//InternalServerError(ex);
            }
        }

   

    }
}

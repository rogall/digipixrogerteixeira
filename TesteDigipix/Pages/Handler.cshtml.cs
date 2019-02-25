using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigipixDomain.Models;
using DigipixServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TesteDigipix.Pages
{
    public class HandlerModel : PageModel
    {
        private IAddressServices _AddressServices;
        public Address Address { get; private set; }

        public HandlerModel(IAddressServices AddressServices)
        {
            _AddressServices = AddressServices;
        }

        public JsonResult OnGetAddressByCEP(string cep)
        {
            Address ret = _AddressServices.GetAddressByCEP(cep);
            return new JsonResult(ret);
        }
    }
}
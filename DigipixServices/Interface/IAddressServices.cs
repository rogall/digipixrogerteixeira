using DigipixDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigipixServices.Interface
{
    public interface IAddressServices
    {
        Address GetAddressByCEP(string cep);
    }
}

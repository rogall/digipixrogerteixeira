﻿using DigipixDomain.Models;
using DigipixServices.Interface;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigipixServices.Concrete
{
    public class AddressServices : IAddressServices
    {
        public Address GetAddressByCEP(string cep)
        {
            Address address;

            //TO DO colocar a url DIGIPIX para autenticação em uma variável de configuração para eliminar hardcode
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://service-homolog.digipix.com.br/v0b/shipments/zipcode/" + cep);
            
            CookieContainer cookies = new CookieContainer();
            request.UseDefaultCredentials = true;
            request.CookieContainer = cookies;
            request.ContentType = "application/json";
            request.CookieContainer = cookies;
           
            //TO DO colocar o JWT para autenticação em uma variável de configuração para eliminar hardcode
            request.Headers.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhdWQiOiJkZXNmaW8uZm90b3JlZ2lzdHJvLmNvbS5iciIsImV4cCI6MTU3NzU1NDEzMywianRpIjoiNzBlODRlZmQtMGRmNC00ZmZhLTlmYTYtNTI1M2ZjNmFmMDgyIiwiaWF0IjoxNTQ2NDUwMTMzLCJpc3MiOiJodHRwczovL3NlcnZpY2UtaG9tb2xvZy5kaWdpcGl4LmNvbS5iciIsInN0b3JlSWQiOjc5LCJzdG9yZU5hbWUiOiJGb3RvcmVnaXN0cm8iLCJzdG9yZVVSTCI6ImRlc2Zpby5mb3RvcmVnaXN0cm8uY29tLmJyIn0.yPFKdRdc4jTAUuziqfkvJm74W5axDelkaH-Q6lBTE8k");
            request.Method = "GET";

            request.ContentLength = 0;
          
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());                   
                    address = JsonConvert.DeserializeObject<Address>(reader.ReadToEnd());

                    if (address == null)
                    {
                        address = new Address();
                        address.message = "Cep não encontrado";
                    }
                }
            }
            catch(Exception ex)
            {
                address = new Address();
                address.message = "Erro ao consultar cep";
            }                       
          
            return address;
        }
    }
}

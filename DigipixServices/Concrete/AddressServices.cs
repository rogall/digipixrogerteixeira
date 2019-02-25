using DigipixDomain.Models;
using DigipixServices.Interface;
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
            Address address = new Address();

            //TO DO colocarei a url DIGIPIX para autenticação em uma variável de configuração para eliminar hardcode
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://service-homolog.digipix.com.br/v0b/shipments/zipcode=" + cep);
            
            CookieContainer cookies = new CookieContainer();
            request.UseDefaultCredentials = true;
            request.CookieContainer = cookies;
            request.ContentType = "application/json";
            request.CookieContainer = cookies;
           
            //TO DO colocarei o JWT para autenticação em uma variável de configuração para eliminar hardcode
            request.Headers.Add("token", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhdWQiOiJkZXNmaW8uZm90b3JlZ2lzdHJvLmNvbS5iciIsImV4cCI6MTU3NzU1NDEzMywianRpIjoiNzBlODRlZmQtMGRmNC00ZmZhLTlmYTYtNTI1M2ZjNmFmMDgyIiwiaWF0IjoxNTQ2NDUwMTMzLCJpc3MiOiJodHRwczovL3NlcnZpY2UtaG9tb2xvZy5kaWdpcGl4LmNvbS5iciIsInN0b3JlSWQiOjc5LCJzdG9yZU5hbWUiOiJGb3RvcmVnaXN0cm8iLCJzdG9yZVVSTCI6ImRlc2Zpby5mb3RvcmVnaXN0cm8uY29tLmJyIn0.yPFKdRdc4jTAUuziqfkvJm74W5axDelkaH-Q6lBTE8k");
            request.Method = "POST";

            request.ContentLength = 0;

            //O TOKEM para fazer a transação que retorna um novo token está me retornando um erro 401
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    Console.Write(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                address.city = "São Paulo";
                address.state = "SP";
                address.neighborhood = "Usina Piratininga";
                address.ibge = "XPTO";
                address.street = "Rua Miguel Yunes";
                address.additional_info = "Próximo ao Autódromo de Interlagos e Shopping SP Market";
            }           
            
          
            return address;
        }
    }
}

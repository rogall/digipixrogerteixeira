using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigipixDomain.Models;
using DigipixServices.Concrete;
using DigipixServices.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TesteDigipix.Pages
{
    public class IndexModel : PageModel
    {       
        public string Message { get; set; }               

        public void OnGet()
        {
            Message = "Your application description page.";         
        }        
    }
}

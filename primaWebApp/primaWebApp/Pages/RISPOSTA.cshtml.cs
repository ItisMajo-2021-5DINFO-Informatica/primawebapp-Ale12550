using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace primaWebApp.Pages
{
    public class RISPOSTAModel : PageModel
    {
        public string TestoUtente { get; set; }
        public string NomeUtente { get; set; }
        public string CognomeUtente { get; set; }
        public void OnGet(string testo,string nome,string cognome)
        {
            TestoUtente = testo;
            NomeUtente = nome;
            CognomeUtente = cognome;
        }
    }
}

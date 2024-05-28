using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HerramientasMates.Pages
{
    public class Index1Model : PageModel
    {
        public bool hayDatos = false;
        public int EnteroA, EnteroB;
        public string BezoutString = string.Empty;          // Declararlo así evita errores por NULL, ver Error CS8618.
        public string McmString = string.Empty;
        public string McdString = string.Empty ;
        public void OnGet()
        {
        }

        public void OnPost() 
        { 
            hayDatos = true;                                    // Has enviado el formulario.
            EnteroA = int.Parse(Request.Form["EnteroA"]);
            EnteroB = int.Parse(Request.Form["EnteroB"]);



            BezoutString = Maths.BezoutDisplay(EnteroA, EnteroB);
            McdString = Maths.mcmDisplay(EnteroA, EnteroB)[0];
            McmString = Maths.mcmDisplay(EnteroA, EnteroB)[1];
        }
    }
}

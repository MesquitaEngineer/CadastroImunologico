using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CadastroImunologico.Pages;

public class ImunologicosModel : PageModel
{
    private readonly ILogger<ImunologicosModel> _logger;
    private readonly Context _context = new Context();

    public IEnumerable<Imunologico>? imunologicos{ get; set;}

    public ImunologicosModel(ILogger<ImunologicosModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGetAsync()
    {

     imunologicos = await _context.Imunologicos?
            .ToListAsync()?? Enumerable.Empty<Imunologico>(); ;
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
               _context.Imunologicos.Remove(new Imunologico{Id=id});
               var count = await _context.SaveChangesAsync();
               
               return RedirectToPage("/Imunologicos/Index");
             
        }

   
   
}
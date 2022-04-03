using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CadastroImunologico.Pages;

public class EditarImunologicoModel : PageModel
{
    private readonly ILogger<EditarImunologicoModel> _logger;
    private readonly Context _context = new Context();
    [BindProperty]
    public Imunologico imunologico{ get; set;}

    public EditarImunologicoModel(ILogger<EditarImunologicoModel> logger)
    {
        _logger = logger;
    }
    public async Task OnGetAsync(int id)
    {
        imunologico = await _context.Imunologicos.FindAsync(id)?? new Imunologico();
    }

    public async Task<IActionResult> OnPostAsync()
    {

        _context.Update(imunologico);

        var count = await _context.SaveChangesAsync();

        return RedirectToPage("/Imunologicos/index");
    }


   

    
}


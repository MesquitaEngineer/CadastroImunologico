using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CadastroImunologico.Pages;

public class CriarImunologicoModel : PageModel
{
    private readonly ILogger<CriarImunologicoModel> _logger;
    private readonly Context _context = new Context();

    [BindProperty]
    public Imunologico imunologico{ get; set;}

    public CriarImunologicoModel(ILogger<CriarImunologicoModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGetAsync()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {

        _context.Add(imunologico);

        var count = await _context.SaveChangesAsync();

        return RedirectToPage("/Imunologicos/index");
    }


   

    
}


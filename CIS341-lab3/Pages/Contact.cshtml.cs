using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIS341_lab3.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactModel? Contact { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
        public void OnGet()
        {
        }
    }
}

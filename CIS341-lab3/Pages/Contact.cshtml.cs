using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace CIS341_lab3.Pages
{
    [BindProperties]
    public class ContactModel : PageModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Debug.WriteLine($"{Name} ({Email}): {Message}");
            Console.WriteLine($"{Name} ({Email}): {Message}");
            return RedirectToPage("Index");
        }
    }
}
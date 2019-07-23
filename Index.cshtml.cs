using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using personal.project.Data;

namespace personal.project.Pages.UrgentCare
{
    public class IndexModel : PageModel
    {
        private readonly personal.project.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(personal.project.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<UrgentCareLocate> UrgentCareLocate { get;set; }

        public ApplicationUser currentUser { get; set; }

        public async Task OnGetAsync()
        {
            UrgentCareLocate = await _context.UrgentCareLocate.ToListAsync();
            currentUser = await _userManager.GetUserAsync(User);
        }
    }
}

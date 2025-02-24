using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TutormatchWeb.Services;
using System;

namespace TutormatchWeb.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly SupabaseService _supabaseService;

        public AdminController(SupabaseService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            ViewData["Layout"] = "_AdminLayout";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var disputes = await _supabaseService.GetDisputes();
            return View(disputes);
        }

        [HttpGet("dispute/{id}")]
        public async Task<IActionResult> Dispute(Guid id)
        {
            var dispute = await _supabaseService.GetDispute(id);
            if (dispute == null)
            {
                return NotFound();
            }
            return View(dispute);
        }

        [HttpPost("dispute/{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] string status)
        {
            var success = await _supabaseService.UpdateDisputeStatus(id, status);
            if (!success)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}

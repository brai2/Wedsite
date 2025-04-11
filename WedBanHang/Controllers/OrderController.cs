using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WedBanHang.Models;

namespace WedBanHang.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Order
        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.ApplicationUser)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
            return View(orders);
        }

        // GET: /Order/Details/5
        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.ApplicationUser)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // GET: /Order/UpdateStatus/5
        [HttpGet]
        public IActionResult UpdateStatus(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            return View(order);
        }

        // POST: /Order/UpdateStatus
        [HttpPost]
        public IActionResult UpdateStatus(int id, OrderStatus status)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            order.Status = status;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



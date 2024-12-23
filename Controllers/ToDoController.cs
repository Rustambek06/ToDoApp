using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.ToDoItems.ToList();
            return View(items);
        }

        [HttpPost]
        public IActionResult Create(ToDoItems item)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoItems.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = _context.ToDoItems.Find(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

         [HttpPost]
        public IActionResult ToggleComplete(int id)
        {
            var item = _context.ToDoItems.Find(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

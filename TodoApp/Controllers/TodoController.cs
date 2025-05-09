using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> _todos = new List<TodoItem>();

        public IActionResult Index()
        {
            return View(_todos);
        }

        [HttpPost]
        public IActionResult Add(string? title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                _todos.Add(new TodoItem { Id = _todos.Count + 1, Title = title });
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.isCompleted = true;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _todos.RemoveAll(t => t.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}

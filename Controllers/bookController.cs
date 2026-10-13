using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    // רשימה סטטית זמנית המדמה מסד נתונים לצורך הדגמה
    private static readonly List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "תכנות מתקדם", Author = "ישראל ישראלי" },
        new Book { Id = 2, Title = "מבני נתונים", Author = "שרה כהן" },
        new Book { Id = 3, Title = "בסיסי נתונים ו-SQL", Author = "דוד לוי" },
        new Book { Id = 4, Title = "פיתוח צד שרת ב-Node.js", Author = "רבקה פרץ" },
        new Book { Id = 5, Title = "יסודות התכנות ב-C#", Author = "משה אברהמי" },
        new Book { Id = 6, Title = "ארכיטקטורה של מערכות מידע", Author = "לאה גולדשטיין" }
    };

    // סוג 1: שליפת כל הרשימה
    // כתובת ה-URL תהיה: GET /api/books
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAllBooks()
    {
        return Ok(_books); // מחזיר את כל הרשימה עם קוד הצלחה 200
    }

    // סוג 2: שליפת פריט בודד לפי מזהה
    // כתובת ה-URL תהיה לדוגמה: GET /api/books/1
    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound(); // מחזיר תשובה 404 אם הספר לא נמצא
        }

        return Ok(book); // מחזיר את הספר שנמצא
    }
}

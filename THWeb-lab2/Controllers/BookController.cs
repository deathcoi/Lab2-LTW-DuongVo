using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using THWeb_lab2.Models;

namespace THWeb_lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public string Hello(string uclass)
        {
            return "Xin chao` may`: Vo trieu Duong - Lop: " + " " + uclass;
        }
        public ActionResult ListBook()
        {
            var book = new List<string>();
            book.Add("HTML5 & CSS3 - Author Book 1");
            book.Add("Python Basic - Author Book 2");
            book.Add("Android Basic - Author Book 3");
            ViewBag.ListBook = book;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 ", "Author Book 1", "/Content/image/html&css.png"));
            books.Add(new Book(2, "Android Basic ", "Author Book 2", "/Content/image/android.png"));
            books.Add(new Book(3, "Python Basic ", "Author Book 3", "/Content/image/python.png"));
            return View(books);

        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 ", "Author Book 1", "/Content/image/html&css.png"));
            books.Add(new Book(2, "Android Basic ", "Author Book 2", "/Content/image/android.png"));
            books.Add(new Book(3, "Python Basic ", "Author Book 3", "/Content/image/python.png"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();

            }
            return View(book);
        }
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string Title, string Author, string Image)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 ", "Author Book 1", "/Content/image/html&css.png"));
            books.Add(new Book(2, "Android Basic ", "Author Book 2", "/Content/image/android.png"));
            books.Add(new Book(3, "Python Basic ", "Author Book 3", "/Content/image/python.png"));
            
            if(id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    b.title = Title;
                    b.author = Author;
                    b.image = Image;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="id,Title,Author,Image")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 ", "Author Book 1", "/Content/image/html&css.png"));
            books.Add(new Book(2, "Android Basic ", "Author Book 2", "/Content/image/android.png"));
            books.Add(new Book(3, "Python Basic ", "Author Book 3", "/Content/image/python.png"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch(RetryLimitExceededException /*dex*/)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

        //xóa nó đi
         public ActionResult Delete(int ?id)
         {
             var books = new List<Book>();
             books.Add(new Book(1, "HTML5 & CSS3 ", "Author Book 1", "/Content/image/html&css.png"));
             books.Add(new Book(2, "Android Basic ", "Author Book 2", "/Content/image/android.png"));
             books.Add(new Book(3, "Python Basic ", "Author Book 3", "/Content/image/python.png"));


                     Book st = books.Find(s => s.Id == id);

                     books.Remove(st);

            //Em khong biết sao mà khi list nó còn 2 book thì xóa cứ bị sao sao ấy ạ.
            //mong thầy giải đáp

             return View("ListBookModel", books);
         }
    }
    }

    [Serializable]
    internal class RetryLimitExceededException : Exception
    {
        public RetryLimitExceededException()
        {
        }

        public RetryLimitExceededException(string message) : base(message)
        {
        }

        public RetryLimitExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RetryLimitExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

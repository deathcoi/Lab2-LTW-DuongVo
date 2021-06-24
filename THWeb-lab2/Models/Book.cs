using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THWeb_lab2.Models
{
    public class Book
    {
        public int id;
        public string title;
        public string author;
        public string image;

        public Book()
        {
        }

        public Book(int id, string title, string author, string image)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image = image;
        }
       
        public int Id { get { return id; } }
        [Required(ErrorMessage = " Not Null")]
        [StringLength(250,ErrorMessage = "Khong qua 250")]
        [Display(Name = "Tieu de")]
        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string Image { get { return image; } set { image = value; } }
    }
   
}
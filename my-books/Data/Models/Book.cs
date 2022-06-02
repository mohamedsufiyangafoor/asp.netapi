using System;
using System.Collections.Generic;

namespace my_books.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
        public DateTime? DateAdded { get; set; }

        // Navigation Properties
        
        // One To Many Relationships
        // PublisherId is the foreign key for book Model
        // PublisherId = Id in the Publisher Model and works as primary key
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }


        // Navigation Properties
        // MANY TO MANY RELATIONSHIPS
        // Because it is M2M we need a intermediate(join) model 
        public List<Book_Author> Book_Authors { get; set; }
    }
}

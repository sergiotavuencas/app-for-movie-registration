using System;

namespace app_for_movie_registration.classes
{
    public class Movie : MovieEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Movie(int Id, Genre Genre, string Title, string Description, int Year)
        {
            this.Id = Id;
            this.Genre = Genre;
            this.Title = Title;
            this.Description = Description;
            this.Year = Year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string dados =
                $"Genre: {this.Genre}" + Environment.NewLine +
                $"Title: {this.Title}" + Environment.NewLine +
                $"Description: {this.Description}" + Environment.NewLine +
                $"Year: {this.Year}" + Environment.NewLine +
                $"Deleted: {this.Deleted}" + Environment.NewLine;

            return dados;
        }

        public int getId()
        {
            return this.Id;
        }

        public void setId(int Id)
        {
            this.Id = Id;
        }

        public string getTitle()
        {
            return this.Title;
        }

        public bool isDeleted()
        {
            return this.Deleted;
        }

        public void Delete() 
        {
            this.Deleted = true;
        }
    }
}
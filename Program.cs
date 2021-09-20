using System;
using app_for_movie_registration.classes;

namespace app_for_movie_registration
{
    class Program
    {
        static MovieRepository repository = new MovieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while(userOption.ToUpper() != "X")
            {
                switch(userOption)
                {
                    case "1":
                        MoviesList();
                        break;
                    
                    case "2":
                        Console.WriteLine(SearchMovie().ToString());
                        break;

                    case "3":
                        repository.Insert(MovieInformations(true));
                        break;

                    case "4":
                        UpdateMovie();
                        break;

                    case "5":
                        DeleteMovie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        break;
                }

                userOption = GetUserOption();
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Choose one of the options:");
            Console.WriteLine(
                "1- List movies\n" +
                "2- Search for a movie\n" +
                "3- Register a new movie\n" +
                "4- Update a movie\n" +
                "5- Delete a movie\n" +
                "C- Clear console");
            Console.WriteLine("X- Sair\n");

            string userOption = Console.ReadLine();

            return userOption;
        }

        private static void MoviesList()
        {
            Console.WriteLine("\nMovies List:\n");

            var list = repository.ListAll();

            if(list.Count == 0)
            {
                Console.WriteLine("Empty list, please register a movie." + Environment.NewLine);
                return;
            }

            Console.WriteLine("#ID - TITLE\n");
            foreach (var movie in list)
            {
                if(!movie.isDeleted())
                {
                    Console.WriteLine(movie.getId() + " - " + movie.getTitle());
                }
            }
        }

        private static Movie SearchMovie()
        {
            Console.WriteLine("\nSearch for a movie:\n");

            Console.Write("Movie ID: ");
            int movieId = int.Parse(Console.ReadLine());

            try
            {
                return repository.GetById(movieId);
            }
            catch
            {
                throw new Exception("Movie not found.");
            }
        }

        private static Movie MovieInformations(bool isNew)
        {
            int selectedGenre = 0;
            int movieYear = 0;

            Console.WriteLine("\nMovie informations:\n");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            while ((selectedGenre < 1) || (selectedGenre > 13)) {
                Console.Write("\nSelect one of the the genres above for the movie: ");
                selectedGenre = int.Parse(Console.ReadLine());
            }

            Console.Write("Movie title: ");
            string movieTitle = Console.ReadLine();

            while((movieYear < 1888) || (movieYear > DateTime.Now.Year))
            {
                Console.Write("Movie year: ");
                movieYear = int.Parse(Console.ReadLine());
            }

            Console.Write("Movie description: ");
            string movieDescription = Console.ReadLine();

            Movie newMovie = new Movie(
                Id: isNew ? repository.NextId() : 0,
                Genre: (Genre)selectedGenre,
                Title: movieTitle,
                Description: movieDescription,
                Year: movieYear
            );

            return newMovie;
        }

        private static void UpdateMovie()
        {
            Console.WriteLine("\nUpdate a movie:");

            Movie movieToUpdate = SearchMovie();
            Movie newMovie = MovieInformations(false);

            int movieId = movieToUpdate.getId();
            newMovie.setId(movieId);

            try
            {
                repository.Update(movieId, newMovie);
            }
            catch
            {
                throw new Exception("Couldn't update the selected movie.");
            }
        }

        private static void DeleteMovie()
        {
            Console.WriteLine("\nDelete a movie:\n");

            Movie movieToDelete = SearchMovie();

            Console.WriteLine("Delete movie? Y-Yes N-No: ");
            string userOption = Console.ReadLine();

            if(userOption.ToUpper() == "Y")
            {
                try
                {
                    repository.Delete(movieToDelete.getId());
                }
                catch
                {
                    throw new Exception("Couldn't delete the selected movie.");
                }
            }
        }
    }
}

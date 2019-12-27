using CultureRecommendation.Domain;
using System;
using System.Collections.Generic;

namespace DummyData
{

    public static class GenerateData
    {

        public static List<Genre> GenerateGenres()
        {

            var listGeneres = new List<Genre>();
            var genre1 = new Genre
            {
                Id = 1,
                Name = "Action"
            };
            var genre2 = new Genre
            {
                Id = 2,
                Name = "Adventure"
            };
            var genre3 = new Genre
            {
                Id = 3,
                Name = "Animation"
            };
            var genre4 = new Genre
            {
                Id = 4,
                Name = "Comedy"
            };
            var genre5 = new Genre
            {
                Id = 5,
                Name = "Crime"
            };

            listGeneres.Add(genre1);
            listGeneres.Add(genre2);
            listGeneres.Add(genre3);
            listGeneres.Add(genre4);
            listGeneres.Add(genre5);

            return listGeneres;
        }

        public static List<Movie> GenerateMovies()
        {
            var listMovies = new List<Movie>();

            var Movie1 = new Movie
            {
                Id = 1,
                OriginalTitle = "Cars",
                ReleaseDate = DateTime.Now,
                Adult = false

            };
            var Movie2 = new Movie
            {
                Id = 2,
                OriginalTitle = "Spider-Man: Into the Spider-Verse",
                ReleaseDate = DateTime.Now,
                Adult = false

            };
            var Movie3 = new Movie
            {
                Id = 3,
                OriginalTitle = "Avengers: Endgame",
                ReleaseDate = DateTime.Now,
                Adult = false
            };
            var Movie4 = new Movie
            {
                Id = 4,
                OriginalTitle = "The Angry Birds Movie 2",
                ReleaseDate = DateTime.Now,
                Adult = false
            };
            var Movie5 = new Movie
            {
                Id=5,
                OriginalTitle = "Inside Out",
                ReleaseDate = DateTime.Now,
                Adult = false
            };

            listMovies.Add(Movie1);
            listMovies.Add(Movie2);
            listMovies.Add(Movie3);
            listMovies.Add(Movie4);
            listMovies.Add(Movie5);

            return listMovies;
        }

        public static List<Cinema> GenerateCinemas()
        {
            var listCinemas = new List<Cinema>();

            var Cinema1 = new Cinema
            {

                Id = 1,
                Name = "Cine Capitol",
                OpenSince = DateTime.Now,
                CityId = 1
            };

            var Cinema2 = new Cinema
            {
                Id = 2,
                Name = "Cineworld",
                OpenSince = DateTime.Now,
                CityId = 2
            };

            var Cinema3 = new Cinema
            {
                Id = 3,
                Name = "Cine Callao",
                OpenSince = DateTime.Now,
                CityId = 3
            };

            listCinemas.Add(Cinema1);
            listCinemas.Add(Cinema2);
            listCinemas.Add(Cinema3);

            return listCinemas;

        }

        public static List<Room> GenerateRooms()
        {
            var listRoom = new List<Room>();

            var Room1 = new Room
            {
                Name = "Room 1",
                Size = "Big",
                Seats = 250,
                CinemaId = 1
            };

            var Room2 = new Room
            {
                Name = "Room 2",
                Size = "Small",
                Seats = 75,
                CinemaId = 2
            };

            var Room3 = new Room
            {
                Name = "Room 3",
                Size = "Big",
                Seats = 250,
                CinemaId = 3
            };

            listRoom.Add(Room1);
            listRoom.Add(Room2);
            listRoom.Add(Room3);

            return listRoom;
        }

        public static List<City> GenerateCities()
        {
            var listCities = new List<City>();

            var city1 = new City
            {
                   Id=1,
                   Name= "Barcelona",
                   Population= "1620000"
            };

            var city2 = new City
            {
                Id = 2,
                Name = "Madrid",
                Population = "3223000"
            };

            var city3 = new City
            {
                Id = 3,
                Name = "London",
                Population = "9126000"
            };

            listCities.Add(city1);
            listCities.Add(city2);
            listCities.Add(city3);

            return listCities;
        }

        public static List<MovieGenre> GenerateMovieGenre()
        {

            var listMovieGenres = new List<MovieGenre>();

            var MovieGenre1 = new MovieGenre
            {
                MovieId = 1,
                GenreId = 3
            };

            var MovieGenre2 = new MovieGenre
            {
                MovieId = 2,
                GenreId = 3
            };

            var MovieGenre3 = new MovieGenre
            {
                MovieId = 2,
                GenreId = 4
            };

            var MovieGenre4 = new MovieGenre
            {
                MovieId = 3,
                GenreId = 3
            };

            var MovieGenre5 = new MovieGenre
            {
                MovieId = 5,
                GenreId = 3
            };

            listMovieGenres.Add(MovieGenre1);
            listMovieGenres.Add(MovieGenre2);
            listMovieGenres.Add(MovieGenre3);
            listMovieGenres.Add(MovieGenre4);
            listMovieGenres.Add(MovieGenre5);

            return listMovieGenres;
        }

        public static List<Session> GenerateSessions()
        {
            var listSessions = new List<Session>();

            var session1 = new Session
            {
                RoomId = 1,
                MovieId = 1,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMonths(3),
                SeatsSold = 1500
            };
            var session2 = new Session
            {
                RoomId = 2,
                MovieId = 2,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMonths(3),
                SeatsSold = 150
            };

            listSessions.Add(session1);
            listSessions.Add(session2);

            return listSessions;
        }

    }

}

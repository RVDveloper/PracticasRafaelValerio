public class VideoGame
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public int TimesRented { get; set; }
        public bool IsRented { get; set; }

        public Employee RentedByEmployee { get; set; }

        public const string Juego = "🎮"; public const string Joystick = "🕹️";

        public VideoGame(string title, int releaseYear, string genre, string developer)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Genre = genre;
            Developer = developer;
            TimesRented = 0;
            IsRented = false;
            RentedByEmployee = null;
        }

        public override string ToString()
        {
            
            return $"{Title} ({ReleaseYear}) - {Genre} | {Developer} | Times rented: {TimesRented}";
        }
    }
namespace BookClub
{
    public class Book : IBook
    {
        private int _bookId;
        private string _title;
        private string _description;
        private string _genre;
        private string _authorLastName;
        private string _authorFirstName;
        private double _rating;
        private int _numberOfReaders;

        //getters and setters
        public int BookId 
        {
            get {
                return _bookId;
            }

            set {
                _bookId = value;
            }
        }
        public string Title 
        {
            get 
            {
                return _title;
            }

            set
            {
                _title = value;
            } 
        }
        public string Description 
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public string Genre 
        {
            get
            {
                return _genre;
            }

            set
            {
                _genre = value;
            }
        }
        public string AuthorLastName 
        {
            get
            {
                return _authorLastName;
            }

            set
            {
                _authorLastName = value;
            }
        }
        public string AuthorFirstName 
        {
            get
            {
                return _authorFirstName;
            }

            set
            {
                _authorFirstName = value;
            }
        }
        public double Rating 
        {
            get
            {
                return _rating;
            }

            set
            {
                _rating = value;
            }
        }
        public int NumberOfReaders 
        {
            get
            {
                return _numberOfReaders;
            }

            set
            {
                _numberOfReaders = value;
            }
        }

        public override string ToString() {
            return BookId + "\n" +
                    Title + "\n" +
                    "Desc: " + Description + "\n" +
                    "Genre: " +Genre + "\n" +
                    AuthorLastName + ", "+ AuthorFirstName + "\n" +
                    "Rating: " + Rating + "\n" +
                    "Number Of Readers: " + NumberOfReaders;
        }
        
    }
}
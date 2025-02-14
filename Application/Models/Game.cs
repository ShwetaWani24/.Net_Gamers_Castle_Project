namespace Entities;



    public class Game
    {
        public int GameId { get; set; } // Primary Key
        public string Title { get; set; } // game_title
        public string Description { get; set; } // description (max length: 500)
        public string ImageUrl { get; set; } // image_url
        public string TrailerUrl { get; set; } // trailer_url
    }



﻿using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    /// <summary>
    /// Represents a single game available for purchase
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The unique identitfier for each game product
        /// </summary>
        [Key]
        public int GameId { get; set; }

        /// <summary>
        /// The title of the Video Game
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The sales price of the game
        /// </summary>
        [Range(0, 1000)]
        public double Price { get; set; }

        //Todo: Add rating
    }
}

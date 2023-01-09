using eTickets.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace eTickets.Data.ViewModels
{
    public class NewMovieVM
    {
        [Display(Description = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Display(Description = "Select actor(s)")]
        [Required(ErrorMessage = "Actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Description = "Select a cinema")]
        [Required(ErrorMessage = "Cinema is required")]
        public int CinemaId { get; set; }

        [Display(Description = "Select a producer")]
        [Required(ErrorMessage = "Producer is required")]
        public int ProducerId { get; set; }
    }
}

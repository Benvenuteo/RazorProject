using MovieRatingSystem.Domain.Entities;

namespace MovieRatingSystem.Models
{
    public class AdminIndexViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<TvShow> TvShows { get; set; }
    }
}

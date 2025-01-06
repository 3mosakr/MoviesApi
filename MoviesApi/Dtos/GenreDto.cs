using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dtos
{
    public class GenreDto
    {
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}

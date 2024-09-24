using System.ComponentModel.DataAnnotations;

namespace AudioLibrary.Models.DTO
{
    public record GenreDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
        string name_of_genre
        );
}

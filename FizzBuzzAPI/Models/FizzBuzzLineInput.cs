using System.ComponentModel.DataAnnotations;

namespace FizzBuzzAPI.Models
{
    public class FizzBuzzLineInput
    {
        [Required]
        [Range(1, 250, ErrorMessage = "The line must be between 1 and 250")]
        public int Line { get; }
        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Words must be between 1 and 1000 characters")]
        public string Word { get; }

        public FizzBuzzLineInput(int line, string word)
        {
            Line = line;
            Word = word;
        }
    }
}

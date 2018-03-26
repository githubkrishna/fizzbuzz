namespace FizzBuzzUI.Models
{
    using System.ComponentModel.DataAnnotations;
    using FizzBuzzDataModels;
    using PagedList;

    /// <summary>
    /// Fizz buzz input model.
    /// </summary>
    public class FizzBuzzViewModel
        {
            /// <summary>
            /// Gets or sets number.
            /// </summary>
            [Required(ErrorMessage = "Please enter a number.")]
            [Range(1, 1000, ErrorMessage = "Enter a number between 1 and 1000.")]
            public int UserInput { get; set; }

            /// <summary>
            /// Gets or sets fizz buzz list.
            /// </summary>
            public PagedList<FizzBuzz> FizzBuzzList { get; set; }
        }
}

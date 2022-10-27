using System.ComponentModel.DataAnnotations;

namespace Blazor1.Client{
    public class CounterModel {
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = $"Number must be between 0 to 2147483647")]
        public int Number { get; set; }

        public CounterModel() {
            Number = 0;
        }
    }
}

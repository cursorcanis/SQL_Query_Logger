using System.ComponentModel.DataAnnotations;

namespace SQL_Query_Logger.Models {
    public class Query {

        public int Id { get; set; }
        public string? Title_of_Query { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Type_of_Query { get; set; }
        //public decimal Price { get; set; }
    }
}

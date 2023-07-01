using System.ComponentModel.DataAnnotations;

namespace Bulky_Web.Models
{
    public class Category
    {

        //key annotation similar to @Id
        [Key]
        public int Id { get; set; }
        
        //required is non-nullable data field
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(1,255)]
        public int Displayorder { get; set; }

        public Category()
        {

        }
        

        public Category(int id, string name, int displayorder)
        {
            Id = id;
            Name = name;
            Displayorder = displayorder;
        }
    }
}

using AUV.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUV.EntityframeworkCore.WebSample
{
    [Table("Users")]
    public class User : IIdentityEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,StringLength(20)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

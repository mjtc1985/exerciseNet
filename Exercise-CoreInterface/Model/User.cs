using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_CoreInterface.Model
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }
    }
}

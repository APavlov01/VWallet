using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWallet
{
    public class Income
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public int TypeId { get; set; }


        public Income(string description, double value, int typeId)
        {
            Description = description;
            Value = value;
            TypeId = typeId;
        }
    }
}

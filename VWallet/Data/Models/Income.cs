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
        public Type Type { get; set; }


        public Income(string description, double value, Type type)
        {
            this.Description = description;
            this.Value = value;
            this.Type = type;
        }
    }
}

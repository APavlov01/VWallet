using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWallet.Data.Models
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public int Type_id { get; set; }



        public Expense(int id, string description, double value, int type_id)
        {
            this.Id = id;
            this.Description = description;
            this.Value = value;
            this.Type_id = type_id;
        }
    }
}

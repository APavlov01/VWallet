using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWallet
{
    public class WalletStatistics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Count { get; set; }

        [Required]
        public int TypeId { get; set; }

        public WalletStatistics(string name, double count, int typeId)
        {
            Name = name;
            Count = count;
            TypeId = typeId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class partylist
    {
        [Key]
        public int partylist_id { get; set; }
        public string? partylist_name { get; set; }
        public int counselordivision_id { get; set; }
    }
}

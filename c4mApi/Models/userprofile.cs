using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class userprofile
    {
        [Key]
        public int user_id { get; set; }
        public int user_cid { get; set; }
        public string? user_login { get; set; }
        public string? user_password { get; set; }
        public string? user_title { get; set; }
        public string? user_name { get; set; }
        public string? user_surname { get; set; }
        public string? user_position { get; set; }
        public int userlevel_id { get; set; }
        public int user_type { get; set; }
        public int user_status { get; set; }
    }
}

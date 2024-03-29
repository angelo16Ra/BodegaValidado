using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request
{
    public class RequestLogin
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string UserName { get; set; } = "";
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Password { get; set; } = "";

    }
}

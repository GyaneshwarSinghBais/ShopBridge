using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
    public class UsersModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; } = null;

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "EmailId")]
        public string EmailId { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "OfficeFlag")]
        public string OfficeFlag { get; set; }

        [Display(Name = "Pwd")]
        public string Pwd { get; set; }

        [Display(Name = "LastPwdChangeDate")]
        public DateTime? LastPwdChangeDate { get; set; }

        [Display(Name = "FlagPwdChange")]
        public string FlagPwdChange { get; set; }

        [Display(Name = "PwdChangeOTP")]
        public int? PwdChangeOTP { get; set; }
    }
}

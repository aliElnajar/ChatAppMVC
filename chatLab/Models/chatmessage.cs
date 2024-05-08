using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace chatLab.Models
{
    [Table("chatmessage")]
    public class chatmessage
    {
        [Key]
        public int id { get; set; }

        public string messagetxt { get; set; }

        [StringLength(50)]
        public string username { get; set; }
        [StringLength(50)]
        public string? groupname { get; set; }

    }
}

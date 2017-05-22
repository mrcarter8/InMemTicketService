using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketDataService.Models
{
    //[Table("Tickets")]
    public class Ticket
    {
        [Key]
        public Guid TicketID { get; set; }
        public string Title { get; set; }
        public int Severity { get; set; }
    }
}
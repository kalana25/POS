using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;


namespace AgendaWeb.Models
{
    public class Communication
    {
        public int Id { get; set; }
        public CommunicationMedium Medium { get; set; }

        [MaxLength(100)]
        public string Value { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; }
    }
}

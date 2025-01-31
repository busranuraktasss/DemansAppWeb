﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DemansAppWeb.Models
{
    public class TraceOfLoves
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public string Phone { get; set; }

        public string PlaceName { get; set; }   
        public string City { get; set; }   
    }
}

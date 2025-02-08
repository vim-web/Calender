using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Clnder.Models
{
    public class TodoTask
    {
            public int Id { get; set; }

            [Required]
            public string Title { get; set; }

            public string Description { get; set; }

            [Required]
            public string Status { get; set; }

            [Required]
            public DateTime DueDate { get; set; }
        }
    }



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XamarinTodo.SQLite.Models
{
    [Table("Todo")]
    public class TodoDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        public DateTime? Deadline { get; set; }

        public bool IsComplete { get; set; }
    }
}

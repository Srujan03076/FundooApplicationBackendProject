using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotesId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime Remainder { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public bool IsPin { get; set; }
        [Required]
        public bool IsTrash { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Modifiedat { get; set; }
        public long Id { get; set; }
        public ICollection<Collaborator> Collaborator { get; set; }
        public ICollection<Label> Label { get; set; }
    }
    
}
      




        

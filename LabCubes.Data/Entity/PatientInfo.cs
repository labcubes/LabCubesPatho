using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabCubes.Data.Entity
{
   public class PatientInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PatientInfoID { get; set; }
        [Required]
        [MaxLength(length: 50)]
        public string PatientInfoName { get; set; }
        [MaxLength(length: 50)]
        public string PatientInfoCaption { get; set; }
        [MaxLength(length: 250)]
        public string PatientInfoDescription { get; set; }
    }
}

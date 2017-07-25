using LabCubes.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabCubes.Data.Entity
{
    public class ReportType : CommonProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ReportTypeID { get; set; }
        [Required]
        [MaxLength(length:50)]
        public string ReportTypeName { get; set; }
        [MaxLength(length: 50)]
        public string ReportTypeCaption { get; set; }
        [MaxLength(length: 250)]
        public string ReportTypeDescription { get; set; }
        
        
    }
}

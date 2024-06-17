using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataBaseFirstApproach.Models;

public partial class DbfirstTable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int EmployeeId { get; set; }

    public string Address { get; set; } = null!;
}

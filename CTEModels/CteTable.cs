using System;
using System.Collections.Generic;

namespace DataBaseFirstApproach.CTEModels;

public partial class CteTable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? DepartName { get; set; }
}

using System.Collections.Generic;
using System;

namespace ElectronicsVendor.Models
{
  public class Component
  {
    public int ComponentId { get; set; }
    public string Type { get; set; }
    public List<ComponentVendor> JoinEntities { get; }
    public List<ModelLine> ModelLines { get; set; }
  }
}
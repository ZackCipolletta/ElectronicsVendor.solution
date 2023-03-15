using System.Collections.Generic;
using System;

namespace ElectronicsVendor.Models
{
  public class ModelLine
  {
    public int ModelLineId { get; set; }
    public string Name { get; set; }
    public int ComponentId { get; set; }
    public Component Component { get; set; }
    public List<ComponentVendor> JoinEntities { get; }
  }
}
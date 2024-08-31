using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurse.Core.SystemContext
{
  public class OperatingSystemContext: SystemContext
  {
    private readonly string _Hostname;

    public OperatingSystemContext()
    {
      _Hostname = Environment.MachineName;
    }

    public string Hostname
    {
      get
      {
        return _Hostname;
      }
    }
  }
}

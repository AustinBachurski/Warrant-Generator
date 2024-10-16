using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarrantGenerator.Interfaces;

public interface IReplacementData
{
    public string target { get; set; }
    public string data { get; set; }
}


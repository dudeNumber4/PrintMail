using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMailStore
{
    /// <summary>
    /// For subsequent read models
    /// </summary>
    public interface IReadModel
    {
        bool Apply();
    }
}

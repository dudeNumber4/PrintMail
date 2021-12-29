using PrintMailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMailDomain
{
    public interface IPrintFileInstanceNotifier
    {
        void Configure(PrintFileInstance instance);
        void Notify();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IPdfService
    {
        public MemoryStream GenerateBudgetReport(Budget budget);
    }
}

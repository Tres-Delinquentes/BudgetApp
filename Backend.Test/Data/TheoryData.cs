using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Test.Data
{
    public class TheoryData<T1> : TheoryData
    {
        /// <summary>
        /// Adds data to the theory data set.
        /// </summary>
        /// <param name="p1">The first data value.</param>
        ///// <param name="p2">The second data value.</param>
        ///// <param name="p3">The third data value.</param>
        public void Add(T1 p1)
        {
            AddRow(p1);
        }
    }
}

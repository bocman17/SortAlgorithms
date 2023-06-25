using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithmsOutput
{
    public class AlgoInfo
    {
        public string Title { get; set; }
        public int InputArrLen { get; set; }
        public long Ticks { get; set; }

        public AlgoInfo(string title)
        {
            Title = title;
        }
    }
}

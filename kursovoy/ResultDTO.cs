using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovoy
{
    internal class ResultDTO
    {
        public int _time { get; }
        public int _avgNumberOfComparisons { get; }
        public bool _status { get; }
        public ResultDTO(int time, int avgNumberOfComparisons, bool status) {
        this._time = time;
        this._avgNumberOfComparisons = avgNumberOfComparisons;
        this._status = status;
        }
    }
}

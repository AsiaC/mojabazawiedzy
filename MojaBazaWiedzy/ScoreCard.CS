using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    public class ScoreCard
    {
        public int score;
        public int UpdateScore()
        {
            return this.score + 1;
        }
    }
}

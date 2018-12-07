using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulated_annealing___Queens_problem
{
    class Configuration
    {
        List<Queen> configuration = new List<Queen>();

        public Configuration(int fieldWidth)
        {
            for (int j = 0; j < fieldWidth; j++)
            {
                //configuration.Add(new Queen(0, j));
                Random r = new Random();
                configuration.Add(new Queen(r.Next(fieldWidth), j));
            }
        }

        public Configuration(List<Queen> configuration)
        {
            for (int i = 0; i < configuration.Count; i++)
            {
                this.configuration.Add(new Queen(configuration[i].i, configuration[i].j));
            }
        }

        public List<Queen> GetList()
        {
            return configuration;
        }

        public int Cost()
        {
            int cost = 0;

            // count conflicts between each queen and every other
            foreach(Queen q in configuration)
            {
                foreach (Queen q2 in configuration)
                {
                    // skip comparison with itslef
                    if (q.i == q2.i && q.j == q2.j)
                        continue;

                    // horizontal and vertical check
                    if (q.i == q2.i || q.j == q2.j)
                        cost++;
                    else
                    { // diagonal check
                        
                        int dV = Math.Abs(q.i - q2.i);  // vertical difference: delta V
                        int dH = Math.Abs(q.j - q2.j);  // horizontal difference: delta H
                        if (dV == dH)
                            cost++;
                    }
                }
            }

            return cost;
        }


    }



}

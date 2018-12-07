using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulated_annealing___Queens_problem
{
    class SimulatedAnnealing
    {
        int fieldSize = 10;
        double temperature = 100000;
        double coolingRate = 0.00003;

        Configuration configuration;
        Configuration bestConfig;

        public int iterations = 0;

        // calculate acceptance probability
        double acceptanceProbability(int cost, int newCost, double temperature)
        {
            // if new solution is better -> accept it (acceptance prob. is 1)
            if (newCost < cost)
            {
                return 1.0;
            }

            // else: calculate acceptance prob.
            return Math.Exp((cost - newCost) / temperature);
        }

        public SimulatedAnnealing(int fieldSize, double temperature, double coolingRate)
        {
            this.fieldSize = fieldSize;
            this.temperature = temperature;
            this.coolingRate = coolingRate;
        }
        
        public void Run()
        {
            configuration = new Configuration(fieldSize);
            
            bestConfig = new Configuration(configuration.GetList());

            while (temperature > 0.0001)
            {
                Configuration newConfig = new Configuration(configuration.GetList());

                Random r = new Random();

                // select random queen in config
                Queen q = newConfig.GetList()[r.Next(newConfig.GetList().Count)];
                //q = adjecentConfig.GetList()[3];


                // select random new position for that queen (has to be in same column) and move queen to new position
                q.i = r.Next(fieldSize);

                // get costs
                int cost = configuration.Cost();
                int newCost = newConfig.Cost();

                // maybe accept new config
                if (acceptanceProbability(cost, newCost, temperature) > r.NextDouble())
                {
                    configuration = new Configuration(newConfig.GetList());
                }

                // set best config
                if (configuration.Cost() < bestConfig.Cost())
                {
                    bestConfig = new Configuration(configuration.GetList());
                }

                // if solution is found: stop
                if (bestConfig.Cost() == 0)
                    break;

                // lower temperature
                temperature *= 1 - coolingRate;
                
                // used only to display total iterations used
                iterations++;
            }
        }

        public int GetFieldSize()
        {
            return fieldSize;
        }

        public Configuration GetConfiguration()
        {
            return configuration;
        }

        public Configuration GetBestConfiguration()
        {
            return bestConfig;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickShooter
{
    class RandomNumberGerator
    {

        #region Fields

        static Random rand;

        #endregion

        #region Public methods

        public static void Initialize()
        {
            rand = new Random();
        }

        public static int Next(int maxValue)
        {
            return rand.Next(maxValue);
        }

        public static float NextFloat (float maxValue)
        {
            return (float)rand.NextDouble() * maxValue;
        }

        public static double NextDouble()
        {
            return rand.NextDouble();
        }


        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Asleep
{
    class FastAsleepMonitor
    {
        public static int numSleeping = 0;
        public static bool isActive = false;
        public static int originalSpeed = 0;
        public static float originalUltraSpeed = 0f;

        public static void OnSleepStarted(Sleepable o)
        {
            numSleeping++;

            var total = Components.LiveMinionIdentities.Count;

            if (numSleeping == total && !isActive)
            {
                Activate();
            }
        }

        public static void OnSleepFinished(Sleepable o)
        {
            if (isActive)
            {
                Deactivate();
            }

            numSleeping--;
        }

        public static void Activate()
        {
            isActive = true;

            SpeedControlScreen sps = SpeedControlScreen.Instance;

            originalSpeed = sps.GetSpeed();
            originalUltraSpeed = sps.ultraSpeed;
            sps.ultraSpeed = 4.0f;
            sps.SetSpeed(2);
        }

        public static void Deactivate()
        {
            isActive = false;

            SpeedControlScreen sps = SpeedControlScreen.Instance;

            sps.ultraSpeed = originalUltraSpeed;
            sps.SetSpeed(originalSpeed);
        }
    }
}

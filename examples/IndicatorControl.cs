using System;
using GTA;

namespace IndicatorControl
{
    /// <summary>
    /// Script to control vehicle turn indicators in GTA V.
    /// </summary>
    /// <remarks>
    /// This script automatically turns on the vehicle's left or right indicators
    /// when the player presses the corresponding movement controls at low speed.
    /// Each indicator turns off automatically after 3 seconds if the control is released.
    /// </remarks>
    public class IndicatorControl : Script
    {
        /// <summary>
        /// Holds <c>two</c> <see cref="bool"/>s representing whether the left (index 0) or right (index 1) indicator is active.
        /// </summary>
        private readonly bool[] _active = new bool[2];

        /// <summary>
        /// Holds <c>two</c> <see cref="DateTime"/>s representing for how much longer the left (index 0) or right (index 1) indicator should be active.
        /// </summary>
        private readonly DateTime[] _timeLeft = new DateTime[2];

        public IndicatorControl()
        {
            Tick += OnTick;

            Interval = 100; //ms
        }

        private void OnTick(object sender, EventArgs e)
        {
            Ped playerPed = Game.LocalPlayerPed;

            //We don't need to check anything if the player is not in a vehicle.
            if (!playerPed.IsInVehicle())
            {
                return;
            }

            Vehicle vehicle = playerPed.CurrentVehicle;

            if (Game.IsControlPressed(Control.VehicleMoveLeftOnly))
            {
                if (vehicle.Speed < 10.0f)
                {
                    vehicle.IsLeftIndicatorLightOn = _active[0] = true;
                    vehicle.IsRightIndicatorLightOn = _active[1] = false;
                    _timeLeft[0] = DateTime.Now + TimeSpan.FromMilliseconds(3000);
                }
            }
            else if (_active[0] && DateTime.Now > _timeLeft[0])
            {
                vehicle.IsLeftIndicatorLightOn = _active[0] = false;
            }

            if (Game.IsControlPressed(Control.VehicleMoveRightOnly))
            {
                if (vehicle.Speed < 10.0f)
                {
                    vehicle.IsLeftIndicatorLightOn = _active[0] = false;
                    vehicle.IsRightIndicatorLightOn = _active[1] = true;
                    _timeLeft[1] = DateTime.Now + TimeSpan.FromMilliseconds(3000);
                }
            }
            else if (_active[1] && DateTime.Now > _timeLeft[1])
            {
                vehicle.IsRightIndicatorLightOn = _active[1] = false;
            }
        }
    }
}

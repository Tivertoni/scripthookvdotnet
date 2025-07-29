//
// Copyright (C) 2015 crosire & kagikn & contributors
// License: https://github.com/scripthookvdotnet/scripthookvdotnet#license
//

using System;
using GTA.Math;

namespace GTA
{
    /// <summary>
    /// Set of enumerations of the available park types for <see cref="TaskInvoker.ParkVehicle(Vehicle, Vector3, float, float, bool)"/>.
    /// </summary>
    public enum ParkType
    {
        Parallel,
        PerpendicularNoseIn,
        PerpendicularBackIn,
        PullOver,
        LeaveParallelSpace,
        BackOutPerpendicularSpace,
        PassengerExit,
        PullOverImmediate,
    }
}

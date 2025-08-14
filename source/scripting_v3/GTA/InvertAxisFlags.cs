//
// Copyright (C) 2015 crosire & kagikn & contributors
// License: https://github.com/scripthookvdotnet/scripthookvdotnet#license
//

using System;

namespace GTA
{
    /// <summary>
    /// Flags indicating which axes are inverted.
    /// </summary>
    [Flags]
    public enum InvertAxisFlags
    {
        /// <summary>No axes are inverted.</summary>
        None = 0,

        /// <summary>The X axis is inverted.</summary>
        X = 1,

        /// <summary>The Y axis is inverted.</summary>
        Y = 2,

        /// <summary>The Z axis is inverted.</summary>
        Z = 4
    }
}

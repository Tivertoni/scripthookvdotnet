//
// Copyright (C) 2025 kagikn & contributors
// License: https://github.com/scripthookvdotnet/scripthookvdotnet#license
//

using System;

namespace GTA
{
    /// <summary>
    /// Flags used for requesting <see cref="WeaponAsset"/>s.
    /// </summary>
    [Flags]
    public enum WeaponScriptResourceFlags : uint
    {
        /// <summary>
        /// Requests the weapon's base animations.
        /// </summary>
        RequestBaseAnims = 1,

        /// <summary>
        /// Requests all animations related to movement, cover, and weapon handling.
        /// </summary>
        RequestCoverAnims = 2,

        /// <summary>
        /// Requests all animations related to melee combat.
        /// </summary>
        RequestMeleeAnims = 4,

        /// <summary>
        /// Requests all animations related to general motion.
        /// </summary>
        RequestMotionAnims = 8,

        /// <summary>
        /// Requests all animations related to stealth actions.
        /// </summary>
        RequestStealthAnims = 16,

        /// <summary>
        /// Requests all animations related to movement variations.
        /// </summary>
        RequestAllMovementVariationAnims = 32,

        /// <summary>
        /// Requests all possible <see cref="WeaponScriptResourceFlags"/> animations.
        /// </summary>
        RequestAllAnims = 31,
    }
}

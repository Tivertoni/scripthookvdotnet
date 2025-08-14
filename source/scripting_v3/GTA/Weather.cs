//
// Copyright (C) 2015 crosire & kagikn & contributors
// License: https://github.com/scripthookvdotnet/scripthookvdotnet#license
//

namespace GTA
{
    /// <summary>
    /// Represents all weather types available in the game.
    /// </summary>
    public enum Weather
    {
        /// <summary>
        /// Weather state is unknown or not set.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Clear skies with very bright sunlight.
        /// </summary>
        ExtraSunny,

        /// <summary>
        /// Mostly clear skies with normal sunlight.
        /// </summary>
        Clear,

        /// <summary>
        /// Light cloud cover with no precipitation.
        /// </summary>
        Clouds,

        /// <summary>
        /// Heavy haze caused by pollution; reduced visibility.
        /// </summary>
        Smog,

        /// <summary>
        /// Thick fog reducing visibility.
        /// </summary>
        Foggy,

        /// <summary>
        /// Full cloud cover; no direct sunlight.
        /// </summary>
        Overcast,

        /// <summary>
        /// Steady rain; may affect vehicle handling.
        /// </summary>
        Raining,

        /// <summary>
        /// Heavy rain accompanied by lightning and thunder.
        /// </summary>
        ThunderStorm,

        /// <summary>
        /// Rain gradually clearing; moving toward clear skies.
        /// </summary>
        Clearing,

        /// <summary>
        /// Balanced weather state; minimal environmental effects.
        /// </summary>
        Neutral,

        /// <summary>
        /// Continuous snowfall; may affect visibility and ground cover.
        /// </summary>
        Snowing,

        /// <summary>
        /// Severe snowstorm with high winds.
        /// </summary>
        Blizzard,

        /// <summary>
        /// Light snow with occasional flurries.
        /// </summary>
        Snowlight,

        /// <summary>
        /// Christmas-themed weather; combines snow and festive ambient effects.
        /// </summary>
        Christmas,

        /// <summary>
        /// Halloween-themed weather; may include fog and special lighting effects.
        /// </summary>
        Halloween,
    }
}

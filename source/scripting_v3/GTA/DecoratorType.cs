//
// Copyright (C) 2023 kagikn & contributors
// License: https://github.com/scripthookvdotnet/scripthookvdotnet#license
//

namespace GTA
{
    /// <summary>
    /// Represents the types of decorators used for attaching metadata to game entities.
    /// </summary>
    public enum DecoratorType
    {
        /// <summary>
        /// Represents an unknown decorator type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Represents a decimal decorator type.
        /// </summary>
        Float,

        /// <summary>
        /// Represents a boolean decorator type.
        /// </summary>
        Bool,

        /// <summary>
        /// Represents an integer decorator type.
        /// </summary>
        Int,

        /// <summary>
        /// Represents a text decorator type.
        /// </summary>
        /// <remarks>
        /// The relevant native functions do not appear in production builds.
        /// </remarks>
        String,

        /// <summary>
        /// Represents a time decorator type.
        /// </summary>
        Time,
    }
}

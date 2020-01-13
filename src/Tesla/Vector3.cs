// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Bytewizer.TinyCLR.Tesla
{
    /// <summary>
    /// Vector3 is a 3-element vector.
    /// </summary>
    public class Vector3
    {
        /// <summary>
        /// Gets or sets the X element.
        /// </summary>
        public double X;

        /// <summary>
        /// Gets or sets the Y element.
        /// </summary>
        public double Y;
        
        /// <summary>
        /// Gets or sets the Z element.
        /// </summary>
        public double Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="X">The X element.</param>
        /// <param name="Y">The Y element.</param>
        /// <param name="Z">The Z element.</param>
        public Vector3(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
}

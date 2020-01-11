// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Bytewizer.TinyCLR.Cube
{
    /// <summary>
    /// Vector2 is a 2-element vector.
    /// </summary>
    public class Vector2
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
        /// Initializes a new instance of the <see cref="Vector2"/> class.
        /// </summary>
        /// <param name="X">The X element.</param>
        /// <param name="Y">The Y element.</param>
        public Vector2(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}

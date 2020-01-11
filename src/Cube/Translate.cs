// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace Bytewizer.TinyCLR.Cube
{
    public class Translate
    {
        /// <summary>
        /// Translate 3D objects to 2D objects.
        /// </summary>
        /// <param name="Points3D">Object in 3D space.</param>
        /// <param name="Points2D">Object in 2D space</param>
        /// <param name="Rotate"></param>
        /// <param name="Position"></param>
        public static void Translate3Dto2D(Vector3[] Points3D, Vector2[] Points2D, Vector3 Rotate, Vector3 Position)
        {
            int OFFSETX = 64;
            int OFFSETY = 32;
            int OFFSETZ = 50;

            double sinax = Math.Sin(Rotate.X * Math.PI / 180);
            double cosax = Math.Cos(Rotate.X * Math.PI / 180);
            double sinay = Math.Sin(Rotate.Y * Math.PI / 180);
            double cosay = Math.Cos(Rotate.Y * Math.PI / 180);
            double sinaz = Math.Sin(Rotate.Z * Math.PI / 180);
            double cosaz = Math.Cos(Rotate.Z * Math.PI / 180);

            for (int i = 0; i < 8; i++)
            {
                double x = Points3D[i].X;
                double y = Points3D[i].Y;
                double z = Points3D[i].Z;

                double yt = y * cosax - z * sinax;  // rotate around the x axis
                double zt = y * sinax + z * cosax;  // using the Y and Z for the rotation
                y = yt;
                z = zt;

                double xt = x * cosay - z * sinay;  // rotate around the Y axis
                zt = x * sinay + z * cosay;         // using X and Z
                x = xt;
                z = zt;

                xt = x * cosaz - y * sinaz;         // finally rotate around the Z axis
                yt = x * sinaz + y * cosaz;         // using X and Y
                x = xt;
                y = yt;

                x = x + Position.X;                 // add the object position offset
                y = y + Position.Y;                 // for both x and y
                z = z + OFFSETZ - Position.Z;       // as well as Z

                Points2D[i].X = (x * 64 / z) + OFFSETX;
                Points2D[i].Y = (y * 64 / z) + OFFSETY;
                //BrainPad.ImageBuffer.DrawPoint((int)Points2D[i].X, (int)Points2D[i].Y);
            }
        }
    }
}

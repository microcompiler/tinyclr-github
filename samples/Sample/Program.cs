using Bytewizer.TinyCLR.Cube;

namespace Bytewizer.TinyCLR.Samples
{
    class Program
    {
        static void Main()
        {
            // our object in 3D space
            Vector3[] cube_points = new Vector3[8]
            {
            new Vector3(10,10,-10),
            new Vector3(-10,10,-10),
            new Vector3(-10,-10,-10),
            new Vector3(10,-10,-10),
            new Vector3(10,10,10),
            new Vector3(-10,10,10),
            new Vector3(-10,-10,10),
            new Vector3(10,-10,10),
            };

            // what we get back in 2D space!
            Vector2[] cube2 = new Vector2[8]
            {
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            };

            // the connections between the "dots"
            int[] start = new int[12] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3 };
            int[] end = new int[12] { 1, 2, 3, 0, 5, 6, 7, 4, 4, 5, 6, 7 };

            Vector3 rot = new Vector3(0, 0, 0);
            Vector3 pos = new Vector3(0, 0, 0);

            while (true)
            {
                double accelX = BrainPad.Accelerometer.ReadX();
                double accelY = BrainPad.Accelerometer.ReadY();
                BrainPad.Display.Clear();
                //rot.Z += 5;
                //rot.X += 5;
                rot.X = 360 - accelY;
                rot.Y = accelX;
                //pos.X += 1;
                Translate.Translate3Dto2D(cube_points, cube2, rot, pos);

                for (int i = 0; i < start.Length; i++)
                {    // draw the lines that make up the object
                    int vertex = start[i];                  // temp = start vertex for this line
                    int sx = (int)cube2[vertex].X;          // set line start x to vertex[i] x position
                    int sy = (int)cube2[vertex].Y;          // set line start y to vertex[i] y position
                    vertex = end[i];                        // temp = end vertex for this line
                    int ex = (int)cube2[vertex].X;          // set line end x to vertex[i+1] x position
                    int ey = (int)cube2[vertex].Y;          // set line end y to vertex[i+1] y position
                    BrainPad.Display.DrawLine(sx, sy, ex, ey);
                }
                BrainPad.Display.DrawSmallText(0, 55, "X: " + (accelX * 100).ToString("F0"));
                BrainPad.Display.DrawSmallText(80, 55, "Y: " + (accelY * 100).ToString("F0"));
                BrainPad.Display.RefreshScreen();
                BrainPad.Wait.Minimum();
            }
        }
    }
}

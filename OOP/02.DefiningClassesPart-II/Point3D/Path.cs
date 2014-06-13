//Task4
//Create a class Path to hold a sequence of points in the 3D space.
//Create a static class PathStorage with static methods to save and load paths from a text file. 
//Use a file format of your choice.

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public class Path 
    {
        public Point3d.strPoint3d point = new Point3d.strPoint3d();      

        // property
        public double X
        {
            get { return point.X; } //getter
            set { point.X = value; } //setter
        }

        public double Y
        {
            get { return point.Y; } //getter
            set { point.Y = value; } //setter
        }

        public double Z
        {
            get { return point.Z; } //getter
            set { point.Z = value; } //setter
        }

        // Constructor
        public Path(double x, double y, double z)
        {
            this.point.X = x;
            this.point.Y = y;
            this.point.Z = z;
        }

        public Path()
        {
            // TODO: Complete member initialization
        }

    }
}

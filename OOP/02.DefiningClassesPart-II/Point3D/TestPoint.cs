using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    class TestPoint
    {
        static void Main()
        {
            Path p = new Path(1,2,3);
            Path d = new Path(3, 4, 4);
            Path c = new Path(5, 6, 7);

            PathStorage.LoadPath(p.ToString()); //Save path in file savedPaths.txt
            string pathBuffer = "savePaths.txt";
            //Path final = PathStorage.LoadPath(pathBuffer); //loading from the file savedPaths.txt

            
        }

    }
}

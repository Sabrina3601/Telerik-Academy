using System;

namespace CohesionAndCoupling
{
    static class Utils
    {
        public static double Width { get; set; }
        public static double Height { get; set; }
        public static double Depth { get; set; }

        public Utils(double width, double height, double depth)
        {
            if (width < 0 || height < 0 || depth < 0)
            {
                throw new ArgumentException("Dimensions cannot be negative.");
            }

            Width = width;
            Height = height;
            Depth = depth;
        }

        public static string GetFileExtension(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("Path is null.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return "";
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("Path is null.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }

        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalcDiagonalXYZ()
        {
            double distance = GeometryUtils.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public static double CalcDiagonalXZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }

        
    }
}

using System;
using System.Drawing;

namespace BinaryDataDecoders.Drawing.MultiScaleImages;

public static class GraphicsEx
{
    public static double MaxLevel(this Size size)
    {
        var maxLength = Math.Max(size.Width, size.Height);
        var maxLevel = Math.Ceiling(Math.Log(maxLength, 2));
        return maxLevel;
    }

    public static Size Scale(this Size size, double factor)
    {
        var newSize = new Size(
            (int)Math.Max(1, Math.Ceiling(size.Width * factor)),
            (int)Math.Max(1, Math.Ceiling(size.Height * factor))
            );
        return newSize;
    }
    public static Point OffSetBy(this Point point, Size size)
    {
        var offsetX = (int)(point.X * size.Width);
        var offsetY = (int)(point.Y * size.Height);
        var offsetPoint = new Point(offsetX, offsetY);
        return offsetPoint;
    }
}

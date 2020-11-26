    var outFile = Path.Combine(outpath,Path.GetFileName(filename));
    using (var bmp = new Bitmap(filename))
    {
        var largest = (double)Math.Max(bmp.Height, bmp.Width);
        var scale =  2000.0 / largest;
        var newSize = new Size((int)Math.Ceiling(bmp.Width * scale), (int)Math.Ceiling(bmp.Height * scale));
        using (var outImage = new Bitmap(bmp, newSize))
        {
            outImage.Save(outFile, ImageFormat.Jpeg);
        }
    }
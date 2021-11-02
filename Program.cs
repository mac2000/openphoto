using System;
using OpenCvSharp;

public static class Program
{
    public static int Main(string[] args)
    {
        if (args.Length == 0 || string.IsNullOrEmpty(args[0])) {
            Console.WriteLine("Path missing, usage example:");
            Console.WriteLine("openphoto.exe /Users/bob/Desktop/me.png");
            return 1;
        }
        
        try {
            var capture = new VideoCapture(0);
            var image = new Mat();
            capture.Read(image);
            var bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
            bitmap.Save(args[0]);
            return 0;
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
            return 1;
        }
    }
}
using System.Drawing;
using System.Drawing.Imaging;


Console.WriteLine("Hello, World!");

public enum PixFormat
{
    R8_G8_B8,
    R8_G8_B8_A8,
    I8,
    R32_G32_B32,
    R32_G32_B32_A32,
    I32
}


public class Image
{
    private byte[] _pixels;
    public int Width { init; get; }
    public int Height { init; get; }
    PixFormat PixFormat;
    int BytesPerPixel =>
    PixFormat switch
    {
        PixFormat.R8_G8_B8 => 3,
        PixFormat.R8_G8_B8_A8 => 4,
        PixFormat.I8 => 1,
        PixFormat.R32_G32_B32 => 3 * 4,
        PixFormat.R32_G32_B32_A32 => 4 * 4,
        PixFormat.I32 => 1 * 4,
        _ => throw new ArgumentException("wrong Pixelformat selected"),
    };

    public void Blit(int xs, int ys, int w, int h, Image dest, int xd, int yd)
    {

    }

    public void SaveAs(string path)
    {
        PixelFormat pf = PixFormat switch
        {
            PixFormat.R8_G8_B8 => PixelFormat.Format24bppRgb,
            PixFormat.R8_G8_B8_A8 => PixelFormat.Format32bppArgb,
            _ => throw new ArgumentException("wrong PixFormat selected"),
        };
    }

    public Image(string path)
    {
        Bitmap bmp = new Bitmap(path);
        PixFormat = bmp.PixelFormat switch
        {
            PixelFormat.Format24bppRgb => PixFormat.R8_G8_B8,
            PixelFormat.Format32bppArgb => PixFormat.R8_G8_B8_A8,
        };

        Width = bmp.Width;
        Height = bmp.Height;

        _pixels = new byte[Width * Height * BytesPerPixel];

    }

    public Image(int width, int height, PixFormat PixFormat)
    {
        this.PixFormat = PixFormat;
        _pixels = new byte[width * height * BytesPerPixel];
    }
}




using System.Drawing;
using System.Drawing.Imaging;


Console.WriteLine("Hello, World!");

Image image = new Image("./img/hfu.jpg");
Image dest = new Image("./img/ibau_gross.jpg");
Console.WriteLine(image);

image.Blit(0, 0, 200, 71, dest, 10, 10);

dest.SaveAs("./img/test.jpg");



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
    public PixFormat PixFormat;
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


    private static void BlitCLip(ref int iSrc, int sizeSrc, ref int sizeBlock, ref int iDest, int sizeDest)
    {
        int deltaMin = Math.Min(Math.Min(iSrc, iDest), 0);

        int deltaMax = Math.Max(Math.Max(iSrc + sizeBlock - sizeSrc, iDest + sizeBlock - sizeDest), 0);

        iSrc += deltaMin;
        iDest += deltaMin;
        sizeBlock += deltaMin;
        sizeBlock -= deltaMax;

        if (sizeBlock < 0)
        {
            sizeBlock = 0;
        }
    }

    delegate void CopyLineFunc(int iSrc, int Dst, int nPixels);

    public void Blit(int xs, int ys, int w, int h, Image dest, int xd, int yd)
    {
        BlitCLip(ref xs, Width, ref w, ref xd, dest.Width);
        BlitCLip(ref ys, Height, ref h, ref yd, dest.Height);

        CopyLineFunc copyLine;

        if (PixFormat == dest.PixFormat)
        {
            copyLine = (int iSrc, int iDest, int nPixels) =>
            {
                Array.Copy(_pixels, iSrc, dest._pixels, iDest, nPixels * BytesPerPixel);
            };
        }
        else
        {
            switch (PixFormat)
            {
                case PixFormat.R8_G8_B8:
                    switch (dest.PixFormat)
                    {
                        case PixFormat.R8_G8_B8:
                            break;
                        case PixFormat.R8_G8_B8_A8:
                            copyLine = (int iSrc, int iDest, int nPixels) =>
                            {
                                for (int x = 0; x < nPixels; x++)
                                {

                                    // dest._pixels[iDest + x * dest.BytesPerPixel] = _pixels[iSrc + x * BytesPerPixel];
                                    // dest._pixels[iDest + (x + 1) * dest.BytesPerPixel] = _pixels[iSrc + (x + 1) * BytesPerPixel];
                                    // dest._pixels[iDest + (x + 2) * dest.BytesPerPixel] = _pixels[iSrc + (x + 2) * BytesPerPixel];
                                    // dest._pixels[iDest + x * dest.BytesPerPixel] = _pixels[iSrc + x * BytesPerPixel];

                                    // int iByteDest = 

                                }
                            };
                            break;
                        case PixFormat.I8:
                            break;
                    }
                    break;
                case PixFormat.R8_G8_B8_A8:
                    switch (dest.PixFormat)
                    {
                        case PixFormat.R8_G8_B8:
                            break;
                        case PixFormat.R8_G8_B8_A8:
                            break;
                        case PixFormat.I8:
                            break;
                    }
                    break;
                case PixFormat.I8:
                    switch (dest.PixFormat)
                    {
                        case PixFormat.R8_G8_B8:
                            break;
                        case PixFormat.R8_G8_B8_A8:
                            break;
                        case PixFormat.I8:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        if (PixFormat != dest.PixFormat)
        {
            throw new Exception("Pixelformat does not match");
        }

        for (int y = 0; y < h; y++)
        {
            int iSrc = ((ys + y) * Width + xs) * BytesPerPixel;
            int iDest = ((yd + y) * Width + xd) * dest.BytesPerPixel;

            Array.Copy(_pixels, iSrc, dest._pixels, iDest, w * BytesPerPixel);

            // for (int x = 0; x < w; x++)
            // {
            //     int iSrc = ((ys + y) * Width + xs + x) * BytesPerPixel;
            //     int iDest = ((yd + y) * Width + xd + x) * dest.BytesPerPixel;
            //     // _pixels[((ys + y) * Width + xs + x) * BytesPerPixel]

            //     for (int b = 0; b < BytesPerPixel; b++)
            //     {
            //         dest._pixels[iDest + b] = _pixels[iSrc + b];
            //     }

            // }
        }


    }


    public void SaveAs(string path)
    {
        PixelFormat pf = PixFormat switch
        {
            PixFormat.R8_G8_B8 => PixelFormat.Format24bppRgb,
            PixFormat.R8_G8_B8_A8 => PixelFormat.Format32bppArgb,
            _ => throw new ArgumentException($"Cannot save pixel format {Enum.GetName<PixFormat>(PixFormat)}.")
        };

        Bitmap bm = new Bitmap(Width, Height, pf);

        int bpp = BytesPerPixel;

        switch (PixFormat)
        {
            case PixFormat.R8_G8_B8:
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int pixIndex = (y * Width + x) * bpp;
                        bm.SetPixel(x, y, Color.FromArgb(_pixels[pixIndex + 0], _pixels[pixIndex + 1], _pixels[pixIndex + 2]));
                    }
                }
                break;
            case PixFormat.R8_G8_B8_A8:
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int pixIndex = (y * Width + x) * bpp;
                        bm.SetPixel(x, y, Color.FromArgb(_pixels[pixIndex + 3], _pixels[pixIndex + 0], _pixels[pixIndex + 1], _pixels[pixIndex + 2]));
                    }
                }
                break;
        }

        bm.Save(path);
    }

    public Image(string path)
    {
        Bitmap bm = new Bitmap(path);
        Width = bm.Width;
        Height = bm.Height;

        PixFormat = bm.PixelFormat switch
        {
            PixelFormat.Format24bppRgb => PixFormat.R8_G8_B8,
            PixelFormat.Format32bppArgb => PixFormat.R8_G8_B8_A8,
            _ => throw new ArgumentException("Unkown pixel format in " + path)
        };

        _pixels = new byte[Width * Height * BytesPerPixel];

        int bpp = BytesPerPixel;

        switch (PixFormat)
        {
            case PixFormat.R8_G8_B8:
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Color col = bm.GetPixel(x, y);

                        int pixIndex = (y * Width + x) * bpp;
                        _pixels[pixIndex + 0] = col.R;
                        _pixels[pixIndex + 1] = col.G;
                        _pixels[pixIndex + 2] = col.B;
                    }
                }
                break;
            case PixFormat.R8_G8_B8_A8:
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Color col = bm.GetPixel(x, y);

                        int pixIndex = (y * Width + x) * bpp;
                        _pixels[pixIndex + 0] = col.R;
                        _pixels[pixIndex + 1] = col.G;
                        _pixels[pixIndex + 2] = col.B;
                        _pixels[pixIndex + 3] = col.A;
                    }
                }
                break;
        }
    }

    public Image(int width, int height, PixFormat PixFormat)
    {
        this.PixFormat = PixFormat;

        Width = width;
        Height = height;

        _pixels = new byte[Width * Height * BytesPerPixel];
    }
}




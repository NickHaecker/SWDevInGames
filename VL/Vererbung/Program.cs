


// B b = new B();
// A a = b;

// a.SayHello();

TwoDObject[] some2DObjects = {
    new Circle{Radius=2},
new Square { Height = 4, Width = 7 },
new Circle { Radius = 7 },
new Square { Height = 1, Width = 3 }
};
// DateTimeOffset now = DateTimeOffset.Now;
// long timestampInSeconds = now.ToUnixTimeMilliseconds();
foreach (TwoDObject t in some2DObjects)
{
    // Console.WriteLine(t.Area());
}
// DateTimeOffset end = DateTimeOffset.Now;
// long endTime = end.ToUnixTimeMilliseconds();

// Console.WriteLine(endTime - timestampInSeconds);
Object[] someObjects = {
    new SimpleCircle{Radius=2},
new SimpleSquare { Height = 4, Width = 7 },
new SimpleCircle { Radius = 7 },
new SimpleSquare { Height = 1, Width = 3 }
};
// DateTimeOffset now2 = DateTimeOffset.Now;
// long timestampInSeconds2 = now.ToUnixTimeMilliseconds();
foreach (Object o in someObjects)
{

    double area = o switch
    {
        SimpleCircle c => c.Radius * c.Radius * Math.PI,
        SimpleSquare s => s.Height * s.Width,
        _ => 0
    };




    //     // Console.WriteLine(t.Area());
    //     double area;


    //     switch (o)
    //     {
    //         case SimpleCircle sC:
    //             area = sC.Radius * sC.Radius * Math.PI;
    //             break;
    //         case SimpleSquare sQ:
    //             area = sQ.Height * sQ.Width;
    //             break;
    //         default:
    //             area = 0;
    //             break;
    //     }



    // if (o is SimpleCircle)
    // {
    //     SimpleCircle sc = (SimpleCircle)o;
    //     // SimpleCircle? sc = o as SimpleCircle;
    //     // if (sc == null)
    //     // {
    //     //     return;
    //     // }
    //     area = sc.Radius * sc.Radius * Math.PI;
    // }
    // else if (o is SimpleSquare)
    // {
    //     SimpleSquare sq = (SimpleSquare)o;
    //     area = sq.Height * sq.Width;
    // }
    // else
    // {
    //     area = 0;
    // }

    // SimpleCircle? sc2 = o as SimpleCircle;
    // if (sc2 != null)
    // {
    //     area = sc2.Radius * sc2.Radius * Math.PI;
    // }
    // Console.WriteLine(area);
}
// DateTimeOffset end2 = DateTimeOffset.Now;
// long endTime2 = end.ToUnixTimeMilliseconds();
// // 
// Console.WriteLine(endTime2 - timestampInSeconds2);
class SimpleCircle
{
    public double Radius;
}

class SimpleSquare
{
    public double Width;
    public double Height;

}







// 

class A
{
    public virtual void SayHello()
    {
        Console.WriteLine("Bonhour");
    }
}
class B : A
{
    public override void SayHello()
    {
        Console.WriteLine("Hello");
    }
}

interface TwoDObject
{
    double Area();
}


class Circle : TwoDObject
{
    public double Radius;
    public double Area()
    {
        return Radius * Radius * Math.PI;
    }
}

class Square : TwoDObject
{
    public double Width;
    public double Height;

    public double Area()
    {
        return Width * Height;
    }
}
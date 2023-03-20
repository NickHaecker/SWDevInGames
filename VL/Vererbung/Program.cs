


// B b = new B();
// A a = b;

// a.SayHello();

TwoDObject[] some2DObjects = {
    new Circle{Radius=2},
new Square { Height = 4, Width = 7 },
new Circle { Radius = 7 },
new Square { Height = 1, Width = 3 }
};

foreach (TwoDObject t in some2DObjects)
{
    Console.WriteLine(t.Area());
}


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
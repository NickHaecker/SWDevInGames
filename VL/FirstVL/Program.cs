// See https://aka.ms/new-console-template for more information

// int a = 3;
// int b = a;
// a = 5;

// Console.WriteLine($"Inhalt von b: {b}");

IntContainer a = new IntContainer { v = 3 };
IntContainer b = a;
a.v = 5;
Console.WriteLine($"Inhalt von b: {b.v}");

int[] y = { 4, 6, 3, 2, 1 }

IntContainer[] containerArray = {
    new IntContainer { v = 3 },
    new IntContainer { v = 5 },
    new IntContainer { v = 7 },
    new IntContainer { v = 1 },
    new IntContainer { v = 2 }
}

class IntContainer
{
    public int v;
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using Fusee.Math.Core;
// See https://aka.ms/new-console-template for more information

// int a = 3;
// int b = a;
// a = 5;

// Console.WriteLine($"Inhalt von b: {b}");

// IntContainer a = new IntContainer { v = 3 };
// IntContainer b = a;
// a.v = 5;
// Console.WriteLine($"Inhalt von b: {b.v}");

// int[] y = { 4, 6, 3, 2, 1 }

// IntContainer[] containerArray = {
//     new IntContainer { v = 3 },
//     new IntContainer { v = 5 },
//     new IntContainer { v = 7 },
//     new IntContainer { v = 1 },
//     new IntContainer { v = 2 }
// }

// class IntContainer
// {
//     public int v;
// }

DateTimeOffset now = DateTimeOffset.Now;
long timestampInSeconds = now.ToUnixTimeSeconds();

Vertex[] vertices = new Vertex[1000000];

for (int i = 0; i < 1000000; i++)
{
    Random random = new Random();
    vertices[i] = new Vertex { Position = random.NextDouble(), Normal = random.NextDouble(), UVW = random.NextDouble() };
}

foreach (Vertex v in vertices)
{
    Console.WriteLine(v.Position);
}

DateTimeOffset end = DateTimeOffset.Now;
long endTime = end.ToUnixTimeSeconds();

Console.WriteLine(endTime - timestampInSeconds);

// struct 77 sekunden, 82
// class 81 sekunden, 81
public class Vertex
{
    public double Position;
    public double Normal;
    public double UVW;
}
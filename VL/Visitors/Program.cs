RenderVisitor v = new RenderVisitor();
Group group = new Group
{
    Name = "44",
    Children ={
    new Sphere{ Name = "55", Radius = 3 },
    new Group{Name="qq",Children ={
    new Cuboid { Name = "11", Width = 1, Height = 1, Depth = 1 },
       new Cuboid { Name = "Just a cube", Width = 1, Height = 1, Depth = 1 },
            new Sphere { Name = "Sphere #2", Radius = 2 }
        }
    },
       new Cuboid { Name = "Just a cube", Width = 1, Height = 1, Depth = 1 }

    }
};


group.Accept(v);



public abstract class GraphOb
{
    public abstract void Accept(Visitor v);
    public string Name = "";
}

public class Cuboid : GraphOb
{
    public double Width; public double Height; public double Depth;

    public override void Accept(Visitor v)
    {
        Console.WriteLine("du humoid");
        v.Visit(this);
    }
}


public class Sphere : GraphOb
{
    public double Radius;

    public override void Accept(Visitor v)
    {
        Console.WriteLine("durch nudeln"); v.Visit(this);
    }
}
public class Group : GraphOb
{
    public List<GraphOb> Children = new List<GraphOb>();

    public override void Accept(Visitor v)
    {
        v.Visit(this);
        Console.WriteLine("was machen sachen");
        foreach (GraphOb go in Children)
        {
            go.Accept(v);
        }
    }
}

public interface Visitor
{
    public void Visit(Sphere s);
    public void Visit(Cuboid c);
    public void Visit(Group g);
    public void Visit(GraphOb g);
}

public class RenderVisitor : Visitor
{
    public void Visit(Sphere s)
    {
        Console.WriteLine(s.Name + s.Radius);
    }

    public void Visit(Cuboid c)
    {
        Console.WriteLine(c.Height + c.Name + c.Width + c.Height);
    }

    public void Visit(Group g)
    {
        Console.WriteLine(g.Name + g.Children.Count);
    }
    public void Visit(GraphOb g)
    {
        Console.WriteLine(g.Name);
        // g.Accept(this);
    }
}
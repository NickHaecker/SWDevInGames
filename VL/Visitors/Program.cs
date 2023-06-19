
Group group = new Group
{
    Name = "44",
    Children ={
    new Sphere
    { Name = "55", Radius = 3 },
    new Group{
        Name="qq",
        Children ={
    new Cuboid { Name = "11", Width = 1, Height = 1, Depth = 1 },
       new Cuboid { Name = "Just a cube", Width = 1, Height = 1, Depth = 1 },
            new Sphere { Name = "Sphere #2", Radius = 2 }

        }
    },
       new Cuboid { Name = "Just a cube", Width = 1, Height = 1, Depth = 1 }

    }
};


group.Render();



public abstract class GraphOb
{
    public abstract void Render();
    public string Name = "";
}

public class Cuboid : GraphOb
{
    public double Width; public double Height; public double Depth;

    public override void Render()
    {
        Console.WriteLine("du humoid");
    }
}


public class Sphere : GraphOb
{
    public double Radius;

    public override void Render()
    {
        Console.WriteLine("durch nudeln");
    }
}
public class Group : GraphOb
{
    public List<GraphOb> Children = new List<GraphOb>();

    public override void Render()
    {
        Console.WriteLine("was machen sachen");
        Iterate();
    }
    private void Iterate()
    {
        foreach (GraphOb go in Children)
        {
            go.Render();
        }
    }
}

public interface Visitor
{
    public void Visit(Sphere s);
    public void Visit(Cuboid c);
    public void Visit(Group g);
}

public class RenderVisitor : Visitor
{
    public void Visit(Sphere s)
    {
        throw new NotImplementedException();
    }

    public void Visit(Cuboid c)
    {
        throw new NotImplementedException();
    }

    public void Visit(Group g)
    {
        throw new NotImplementedException();
    }
}
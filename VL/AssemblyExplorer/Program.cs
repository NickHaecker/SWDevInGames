using System.Reflection;

// E:\Projekte\HFU\SWDevInGames\VL\Library\bin\Debug\net7.0\Library.deps.json

Assembly assembly = Assembly.LoadFrom("E:\\Projekte\\HFU\\SWDevInGames\\VL\\Library\\bin\\Debug\\net7.0\\Library.dll");
Type[] types = assembly.GetTypes();

foreach (Type type in types)
{
    Console.WriteLine("Typ\n");
    Console.WriteLine(type.FullName);
    Console.WriteLine("Methoden\n");
    // type.GetMethods().ToList().ForEach(method => Console.WriteLine(method.GetMethodBody()?.GetILAsByteArray()?.ForEach(il => Console.WriteLine(il))));
    // Console.WriteLine("Felder\n");
    // type.GetFields().ToList().ForEach(field => Console.WriteLine(field.Name));
    // Console.WriteLine("Properties\n");
    // type.GetProperties().ToList().ForEach(property => Console.WriteLine(property.Name));
}





public class Test : Attribute
{
    public Test()
    {
        Console.WriteLine("Test");
    }
}
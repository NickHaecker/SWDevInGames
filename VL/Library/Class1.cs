namespace Library;
public class Class1
{
    public void CallMe(int param1, string param2)
    {
        System.Console.WriteLine(param1 + param2);
    }
    public int IntField;
    public string StrProp { get; set; } = "";
}

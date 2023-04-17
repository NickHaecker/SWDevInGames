﻿int[] arr = new int[4];
arr[0] = 33;
arr[1] = 3;
arr[2] = 333;
arr[3] = 3333;

foreach (int i in arr)
{
    Console.WriteLine(i);
}

Collection col = new Collection();

col.Add(33);
col.Add(3);
col.Add(333);
col.Add(3333);
col.Add(33334);

for (int i = 0; i < col.Count; i++)
{
    Console.WriteLine(col.GetAt(i));
}

StringCollection cosl = new StringCollection();

cosl.Add("33");
cosl.Add("3");
cosl.Add("333");
cosl.Add("3333");
cosl.Add("33334");

ObjectCollection ll = new ObjectCollection();

ll.Add(33);
ll.Add("3");
ll.Add(true);
ll.Add(false);
ll.Add("33334");
ll.Add(343334);

public class Collection
{
    private int[] _values = new int[0];
    private int _n;

    public Collection()
    {
        _values = new int[4];
        _n = 0;
    }

    public void Add(int val)
    {
        if (_n >= _values.Length)
        {
            int[] newArr = new int[_values.Length * 2];
            Array.Copy(_values, newArr, _values.Length);
            _values = newArr;
        }
        _values[_n++] = val;
    }
    public int GetAt(int i)
    {
        return _values[i];
    }
    public int Count
    {
        get
        {
            return _n;
        }
    }
}

public class ObjectCollection
{
    private object[] _values = new object[0];
    private int _n;

    public ObjectCollection()
    {
        _values = new object[4];
        _n = 0;
    }

    public void Add(object val)
    {
        if (_n >= _values.Length)
        {
            object[] newArr = new object[_values.Length * 2];
            Array.Copy(_values, newArr, _values.Length);
            _values = newArr;
        }
        _values[_n++] = val;
    }
    public object GetAt(int i)
    {
        return _values[i];
    }
    public int Count
    {
        get
        {
            return _n;
        }
    }
}


public class StringCollection
{
    private string[] _values = new string[0];
    private int _n;

    public StringCollection()
    {
        _values = new string[4];
        _n = 0;
    }

    public void Add(string val)
    {
        if (_n >= _values.Length)
        {
            string[] newArr = new string[_values.Length * 2];
            Array.Copy(_values, newArr, _values.Length);
            _values = newArr;
        }
        _values[_n++] = val;
    }
    public string GetAt(int i)
    {
        return _values[i];
    }
    public int Count
    {
        get
        {
            return _n;
        }
    }
}
public class MyCollection<T>
{
    private T[] _theObjects;
    private int _n;

    public MyCollection()
    {
        _theObjects = new T[2];
        _n = 0;
    }

    public void Add(T o)
    {
        // If necessary, grow the array
        if (_n == _theObjects.Length)
        {
            T[] oldArray = _theObjects;
            _theObjects = new T[2 * oldArray.Length];
            Array.Copy(oldArray, _theObjects, _n);
        }

        _theObjects[_n] = o;
        _n++;
    }

    public T GetAt(int i)
    {
        return _theObjects[i];
    }

    public int Count
    {
        get { return _n; }
    }
}
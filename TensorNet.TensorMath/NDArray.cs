namespace TensorNet.TensorMath;

public partial class NDArray
{
    public int Dim { get; private set; }
    public int[] Shape {
        get
        {
            if (IsScala) return ReadOnly.EmptyShape;
            var prev = this._data![0].Shape;
            var l = new List<int>();
            l.Add(_data!.Length);
            l.AddRange(prev);
            return l.ToArray();
        }
    }
    private NDArray[]? _data;
    private float? _scala;
    
    public bool IsScala => _scala.HasValue;
    public bool IsArray => _data != null;

    public dynamic ToArray()
    {
        if (IsScala) return this._scala!.Value;
        var l = new List<dynamic>();
        foreach (var item in _data!)
        {
            l.Add(item.ToArray());
        }
        return l.ToArray();
    }
    
    
    public string ToString() => $"NDArray({string.Join(", ", Shape)})";
}


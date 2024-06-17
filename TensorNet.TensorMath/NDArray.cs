using System.Numerics;

namespace TensorNet.TensorMath;

public partial class NDArray<T> where T : IAdditionOperators<T, T, T>
{
    public int Dim { get; private set; }

    public int[] Shape
    {
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

    private NDArray<T>[]? _data;
    private T? _scala;

    public bool IsScala => _data == null;
    public bool IsArray => _data != null;

    public dynamic ToArray()
    {
        if (IsScala) return this._scala!;
        var l = new List<dynamic>();
        foreach (var item in _data!)
        {
            l.Add(item.ToArray());
        }

        return l.ToArray();
    }


    public override string ToString() => $"NDArray({string.Join(", ", Shape)})";
}
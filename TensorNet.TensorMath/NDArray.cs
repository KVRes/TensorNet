using System.Numerics;

namespace TensorNet.TensorMath;

public partial class NDArray<T> where T : INumber<T>
{
    public int Dim { get; private set; }

    public int[] Shape
    {
        get
        {
            if (IsScalar) return ReadOnly.EmptyShape;
            var prev = this._data![0].Shape;
            var l = new List<int>();
            l.Add(_data!.Length);
            l.AddRange(prev);
            return l.ToArray();
        }
    }

    private NDArray<T>[]? _data;
    private T? _scalar;

    public bool IsScalar => _data == null;
    public bool IsArray => _data != null;

    public dynamic ToArray()
    {
        if (IsScalar) return this._scalar!;
        var l = new List<dynamic>();
        foreach (var item in _data!)
        {
            l.Add(item.ToArray());
        }

        return l.ToArray();
    }


    public NDArray<T> Copy()
    {
        if (this.IsScalar) return new NDArray<T>(scalar: _scalar);

        var m = new NDArray<T>([_data.Length]);
        for (int i = 0; i < _data.Length; i++)
        {
            m._data[i] = _data[i].Copy();
        }

        return m;
    }


    public override string ToString() => $"NDArray({string.Join(", ", Shape)})";
}
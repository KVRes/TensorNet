using System.Numerics;

namespace TensorNet.TensorMath;

public partial class NDArray<T> where T : INumber<T>
{
    public void AddScala(T val)
    {
        if (IsScalar)
        {
            _scalar = _scalar += val;
            return;
        }

        foreach (var item in _data!)
        {
            item.AddScala(val);
        }
    }

    public static NDArray<T> operator +(NDArray<T> a, T b)
    {
        var res = a.Copy();
        res.AddScala(b);
        return res;
    }

    public void Add(NDArray<T> o)
    {
        if (IsScalar != o.IsScalar) throw new InvalidOperationException("Should be same scalar");
    }
}
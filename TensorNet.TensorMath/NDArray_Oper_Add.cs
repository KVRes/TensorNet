using System.Numerics;

namespace TensorNet.TensorMath;

public partial class NDArray<T> where T : INumber<T>
{
    public void AddScalar(T val)
    {
        if (IsScalar)
        {
            _scalar += val;
            return;
        }

        foreach (var item in _data!)
        {
            item.AddScalar(val);
        }
    }

    public void Add(NDArray<T> o)
    {
        if (o.IsScalar)
        {
            AddScalar(o._scalar);
            return;
        }
        if (IsScalar != o.IsScalar) throw new InvalidOperationException("Should be same scalar");
        throw new NotImplementedException("");
    }
    
    public static NDArray<T> operator +(NDArray<T> a, T b)
    {
        var res = a.Copy();
        res.AddScalar(b);
        return res;
    }
    
    public static NDArray<T> operator +(NDArray<T> a, NDArray<T> b)
    {
        var res = a.Copy();
        res.Add(b);
        return res;
    }
}
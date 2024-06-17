using System.Numerics;
using TensorNet.TensorMath.Extension;

namespace TensorNet.TensorMath;

public partial class NDArray<T> where T : INumber<T>
{
    public NDArray<T> Index(int v)
    {
        if (IsScalar) throw new InvalidOperationException("Cannot index a scalar");
        if (v >= 0) return _data![v];
        return _data![_data!.Length + v];
    }

    public NDArray<T> this[int idx]
    {
        get => Index(idx);
        set
        {
            if (this[idx].Shape != value.Shape)
                throw new InvalidOperationException("should be same shape");
            if (IsScalar) this._scalar = value._scalar;
            else this._data = value._data;
        }
    }
}
using System.Numerics;

namespace TensorNet.TensorMath;

public partial class NDArray<T> where T : INumber<T>
{
    public void Map(Func<T, T> f)
    {
        if (IsScalar)
        {
            _scalar = f(_scalar);
            return;
        }

        foreach (var item in _data!)
        {
            item.Map(f);
        }
    }

    public void Pow(int n)
    {
        this.Map((x) =>
        {
            var raw = x;
            for (int i = 0; i < n; ++i) x *= raw;
            return x;
        });
    }

    public static NDArray<T> operator ^(NDArray<T> a, int b)
    {
        var res = a.Copy();

        return res;
    }
}
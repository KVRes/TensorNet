using System.Numerics;
using System.Xml.Xsl;

namespace TensorNet.TensorMath;

public partial class NDArray<T> where T : INumber<T>
{
    public void MulScalar(T val)
    =>  this.Map((x) => x * val);

    public void Mul(NDArray<T> o)
    {
        if (o.IsScalar)
        {
            MulScalar(o._scalar);
            return;
        }
        
        var l = Shape;
        var r = o.Shape;
        if (l[^1] != r[0]) throw new InvalidOperationException("should be MxN * NxB");
        throw new NotImplementedException("");
    }
    
    public static NDArray<T> operator *(NDArray<T> a, T b)
    {
        var res = a.Copy();
        res.MulScalar(b);
        return res;
    }
    
    public static NDArray<T> operator *(NDArray<T> a, NDArray<T> b)
    {
        var res = a.Copy();
        res.MulScalar(b);
        return res;
    }
}
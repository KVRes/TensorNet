using System.Numerics;
using TensorNet.TensorMath.Extension;

namespace TensorNet.TensorMath;

public partial class NDArray<T> where T : IAdditionOperators<T, T, T>
{
    public dynamic Raw => IsScala ? this._scala! : this._data!;
    
    public NDArray(int[] shape, Func<T>? initializer = null)
    {
        initializer ??= Random.Default<T>;
        
        this.Dim = shape.Length;
        if (shape.Length == 0)
        {
            this._scala = initializer();
            return;
        }
        
        this._data = new NDArray<T>[shape[0]];
        var tail = shape[1..];
        for (int i = 0; i < shape[0]; i++)
        {
            this._data[i] = new NDArray<T>(tail, initializer);
        }
    }
    
    public NDArray(T scalar)
    {
        this.Dim = 0;
        this._scala = scalar;
    }
}
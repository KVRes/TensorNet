namespace TensorNet.TensorMath;

public partial class NDArray
{
    public NDArray(int[] shape, Func<float>? initializer = null)
    {
        initializer ??= Random.Zero;
        
        this.Dim = shape.Length;
        if (shape.Length == 0)
        {
            this._scala = initializer();
            return;
        }
        this._data = new NDArray[shape[0]];
        var tail = shape[1..];
        for (int i = 0; i < shape[0]; i++)
        {
            this._data[i] = new NDArray(tail, initializer);
        }
    }
    
    public NDArray(float scalar)
    {
        this.Dim = 0;
        this._scala = scalar;
    }
}
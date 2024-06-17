namespace TensorNet.TensorMath;

public class DynamicArray
{
    private dynamic _data;
    public DynamicArray(dynamic data)
    {
        _data = data;
    }

    public NDArray AsArray() => (NDArray)_data;

    public float AsScala() => (float)_data;
    
    public dynamic RawValue => _data;

    public int[] Shape => _data is NDArray array ? array.Shape : ReadOnly.EmptyShape;
    
    public string ToString() => _data.ToString();
}
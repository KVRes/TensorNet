namespace TensorNet.TensorMath;

public class NDArray
{
    public int Dim { get; private set; }
    public int[] Shape { get; private set; }
    public float[] Data { get; private set; }
    
    public string ToString() => $"NDArray({string.Join(", ", Shape)})";
}


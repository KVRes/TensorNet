using TensorNet.TensorMath;
using TensorNet.TensorMath.Extension;
using Random = TensorNet.TensorMath.Random;

namespace TensorNet.TensorMathTest;

public class NDArray_Oper
{

    [Test]
    public void Test1()
    {
        var arr = new NDArray<float>(shape: [2, 3], initializer: Random.Zero);
        arr.Shape.Output();
        var t = arr + 1;
        JOut.WriteLine(arr.ToArray());
        JOut.WriteLine(t.ToArray());
    }
    
    [Test]
    public void Test2()
    {
        var arr = 18.AsNDArray();
        var vector = new NDArray<int>(shape: [2]);
        vector[1] = arr;
        JOut.WriteLine(vector.ToArray());
    }
}
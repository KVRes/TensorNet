using TensorNet.TensorMath;
using TensorNet.TensorMath.Extension;
using Random = TensorNet.TensorMath.Random;

namespace TensorNet.TensorMathTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var arr = new NDArray<float>(shape: [2, 3]);
        arr.Shape.Output();
        JOut.WriteLine(arr.ToArray());
    }
    
    [Test]
    public void Test2()
    {
        var arr = new NDArray<float>(shape: [3, 3], initializer: Random.NormalInitializer(0, 1));
        Console.WriteLine("HI");
        arr.Shape.Output();
        JOut.WriteLine(arr.ToArray());
    }
}
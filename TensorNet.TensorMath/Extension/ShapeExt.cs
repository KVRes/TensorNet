using System.Numerics;

namespace TensorNet.TensorMath.Extension;

public static class ShapeExt
{
    public static int[] Shape<T>(this NDArray<T> array) where T : INumber<T> => array.Shape;
    public static int[] Shape(this float scalar) => ReadOnly.EmptyShape;

    public static NDArray<T> AsNDArray<T>(this T scalar) where T : INumber<T> => new NDArray<T>(scalar: scalar);
}
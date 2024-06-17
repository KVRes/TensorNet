using System.Numerics;

namespace TensorNet.TensorMath.Extension;

public static class ShapeExt
{
    public static int[] Shape<T>(this NDArray<T> array) where T : IAdditionOperators<T, T, T> => array.Shape;
    public static int[] Shape(this float scalar) => ReadOnly.EmptyShape;
}
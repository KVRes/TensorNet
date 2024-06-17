namespace TensorNet.TensorMath.Extension;

public static class ShapeExt
{
    public static int[] Shape(this NDArray array) => array.Shape;
    public static int[] Shape(this float scalar) => ReadOnly.EmptyShape;
    public static int[] Shape(this DynamicArray array) => array.Shape;
}
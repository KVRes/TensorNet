namespace TensorNet.TensorMath;

public class Random
{
    private static System.Random _r = new();
    public static float Zero() => 0;

    public static float One() => 1;
    public static Func<float> ConstantInitializer(float val) => () => val;

    public static float Normal(float mu = 0, float sigma = 1)
    {
        var u1 = _r.NextDouble();
        var u2 = _r.NextDouble();

        var randStdNorm =
            Math.Sqrt(-2.0 * Math.Log(u1)) *
            Math.Sin(2.0 * Math.PI * u2);

        var randNorm = mu + sigma * randStdNorm;

        return (float)randNorm;
    }

    public static Func<float> NormalInitializer(float mu = 0, float sigma = 1)
        => () => Normal(mu, sigma);
}
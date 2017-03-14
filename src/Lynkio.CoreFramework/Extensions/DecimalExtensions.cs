namespace Lynkio.CoreFramework.Extensions
{
    public static class DecimalExtensions
    {
        public static bool? IsOutOfLimits(this decimal meas, decimal min, decimal max)
        {
            try
            {
                return meas > min && meas <= max;
            }
            catch
            {
                return null;
            }
        }
    }
}

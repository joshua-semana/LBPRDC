namespace LBPRDC.Source.Config
{
    public class NumericConstants
    {
        public static decimal GetNetBilling(decimal value) => Convert.ToDecimal((double)value / 1.12 * 0.07);
    }
}

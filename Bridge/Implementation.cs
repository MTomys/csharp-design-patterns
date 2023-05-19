namespace Bridge
{
    public abstract class Menu
    {
        public abstract int CalculatePrice();
    }

    public interface ICoupon
    {
        int CouponValue { get; }
    }
    
    public class NoCoupon : ICoupon
    {
        public int CouponValue => 0;
    }
    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue => 1;
    }
    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue => 2;
    }
}
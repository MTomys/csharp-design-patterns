using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuroCoupon();

var meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.Write(meatBasedMenu.CalculatePrice());
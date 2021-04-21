using System;

namespace CompositePattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var singleGift = new SingleGift("TEst", 10);
            Console.WriteLine(singleGift.CalculateTotalPrice());

            var compositeGifts = new Composite("RootBox", 0);
            var singleGift2 = new SingleGift("wow", 50);
            var singleGift3 = new SingleGift("te", 80);

            compositeGifts.Add(singleGift2);
            compositeGifts.Add(singleGift3);

            Console.WriteLine(compositeGifts.CalculateTotalPrice());
        }
    }
}

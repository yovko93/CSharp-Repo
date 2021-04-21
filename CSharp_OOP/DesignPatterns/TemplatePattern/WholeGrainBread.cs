using System;

namespace TemplatePattern
{
    class WholeGrainBread : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("10 min");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("a lot of seeds");
        }

        public override void Slice()
        {
            Console.WriteLine("Sliced 2");
        }
    }
}

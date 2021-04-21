namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (base.BulletsCount < 1)
            {
                return 0;
            }

            base.BulletsCount -= 1;
            return 1;
        }
    }
}

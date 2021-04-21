namespace TemplatePattern
{
    public abstract class Bread
    {

        public abstract void Bake();

        public abstract void MixIngridients();

        public abstract void Slice();

        public void Make()
        {
            this.MixIngridients();
            this.Bake();
            this.Slice();
        }
    }
}

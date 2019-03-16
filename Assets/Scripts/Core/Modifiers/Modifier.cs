namespace Fizz6.Core
{
    public partial class Modifiable<T>
    {
        public class Modifier
        {
            private Modifiable<T> modifiable = null;

            private Transformation transformation = null;

            public Modifier(Modifiable<T> modifiable, Transformation transformation)
            {
                this.modifiable = modifiable;
                this.transformation = transformation;
            }

            public Transformation Transformation
            {
                get
                {
                    return this.transformation;
                }

                set
                {
                    this.Modify(value);
                }
            }

            public void Modify(Transformation transformation)
            {
                this.transformation = transformation;
                this.modifiable.Update();
            }

            public void Destroy()
            {
                this.modifiable.Destroy(this);
            }
        }
    }
}
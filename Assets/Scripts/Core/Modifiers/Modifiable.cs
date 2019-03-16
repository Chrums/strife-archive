using System.Collections.Generic;

namespace Fizz6.Core
{
    public partial class Modifiable<T> where T : new()
    {
        public static implicit operator T(Modifiable<T> modifiable)
        {
            return modifiable.Value;
        }

        public delegate void Transformation(ref T value);

        private List<Modifier> modifiers = new List<Modifier>();

        public delegate void OnChangeDelegate();
        public OnChangeDelegate OnChange = default;

        public T Value
        {
            get;
            private set;
        }
        = default;

        public Modifier Modify(Transformation transformation)
        {
            Modifier modifier = new Modifier(this, transformation);
            this.modifiers.Add(modifier);
            this.Update();
            return modifier;
        }

        public void Destroy(Modifier wrapper)
        {
            this.modifiers.Remove(wrapper);
            this.Update();
        }

        private void Update()
        {
            T value = new T();
            this.modifiers.ForEach(modifier => modifier.Transformation(ref value));
            this.Value = value;
            this.OnChange?.Invoke();
        }
    }
}
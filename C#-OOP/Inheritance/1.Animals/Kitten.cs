namespace Animals
{
    public class Kitten : Cat
    {
        private const string TheGender = "Female";
        public Kitten(string name, int age) : base(name, age, TheGender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}

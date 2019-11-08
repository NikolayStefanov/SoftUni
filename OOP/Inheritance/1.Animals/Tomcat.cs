namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TheGender = "Male";
        public Tomcat(string name, int age) : base(name, age, TheGender)
        {
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}

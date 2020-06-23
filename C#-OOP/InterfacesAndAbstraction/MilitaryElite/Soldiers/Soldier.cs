using _8.MilitaryElite.Interfaces;
namespace _8.MilitaryElite.Soldiers
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
        }
        public string FirstName { get; }

        public string LastName { get; }

        public int ID { get; }
    }
}

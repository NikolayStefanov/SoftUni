using _8.MilitaryElite.Enums;

namespace _8.MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get;}
        public State State { get; }
        public void CompleteMission();
    }
}

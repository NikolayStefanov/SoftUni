using System.Collections.Generic;
using System.Text;
using _8.MilitaryElite.Interfaces;

namespace _8.MilitaryElite.Soldiers
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, List<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public List<IPrivate> Privates { get; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var priv in this.Privates)
            {
                sb.AppendLine("  " + priv.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

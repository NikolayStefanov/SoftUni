namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;
    using _03BarracksFactory.Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var theUnitType = Type.GetType($"{typeof(Unit).Namespace}.{unitType}");
            var unit = (IUnit)Activator.CreateInstance(theUnitType, true);
            return unit;

        }
    }
}

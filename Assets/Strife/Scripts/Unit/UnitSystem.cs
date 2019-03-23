using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public class UnitSystem : Singleton<UnitSystem>
    {
        public List<Unit> Units
        {
            get;
            private set;
        }
        = new List<Unit>();

        public Unit Add(Player player, GameObject unitPrefab)
        {
            GameObject unitObject = Object.Instantiate(unitPrefab);
            Unit unit = unitObject.GetComponent<Unit>();

            if (unit == null)
            {
                Debug.LogError("Invalid prefab used to instantiate a Unit.");
                return null;
            }

            unit.Initialize(player);
            this.Units.Add(unit);
            return unit;
        }

        public bool Remove(Unit unit)
        {
            return this.Units.Remove(unit);
        }
    }
}
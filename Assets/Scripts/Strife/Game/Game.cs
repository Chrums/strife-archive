using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public class Game : Singleton<Game>
    {
        [SerializeField]
        private Camera camera = null;

        [SerializeField]
        private Player player = null;

        [SerializeField]
        private GameObject unitPrefab = null;

        private Unit unit = null;

        protected void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                Unit cunit = UnitManager.Instance.Add(player, unitPrefab);
                if (i == 0)
                {
                    camera.gameObject.GetComponent<FogOfWar>().player = cunit.transform;
                }
            }
        }

        private void Update()
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    RaycastHit raycastHit;
            //    Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);
            //    Physics.Raycast(ray, out raycastHit);
            //    Unit unit = raycastHit.transform.gameObject.GetComponentInParent<Unit>();
            //    if (unit != null)
            //    {
            //        this.unit = unit;
            //    }
            //}

            //if (Input.GetMouseButtonDown(1))
            //{
            //    RaycastHit raycastHit;
            //    Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);
            //    Physics.Raycast(ray, out raycastHit);
            //    if (this.unit != null)
            //    {
            //        UnitMovementBehavior unitMovementBehavior = this.unit.GetComponent<UnitMovementBehavior>();
            //        if (unitMovementBehavior != null)
            //        {
            //            unitMovementBehavior.Target = raycastHit.point;
            //        }
            //    }
            //}
        }
    }
}
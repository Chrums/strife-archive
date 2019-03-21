using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public class Game : Singleton<Game>
    {
        private new Camera camera = null;

        [SerializeField]
        private Player player = null;

        [SerializeField]
        private GameObject unitPrefab = null;

        protected void Start()
        {
            this.camera = Camera.main;
            for (int i = 0; i < 100; i++)
            {
                UnitManager.Instance.Add(player, unitPrefab);
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
        }
    }
}
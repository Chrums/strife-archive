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
            for (int i = 0; i < 1000; i++)
            {
                Unit unit = UnitManager.Instance.Add(player, unitPrefab);
                unit.transform.position = new Vector3(Random.Range(0.0f, 100.0f), 0.0f, Random.Range(0.0f, 100.0f));
                if (i == 0)
                {
                    this.camera.gameObject.GetComponent<FogOfWar>().player = unit.transform;
                }
            }
        }

    }
}
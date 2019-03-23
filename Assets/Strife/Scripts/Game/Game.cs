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
                Unit unit = UnitSystem.Instance.Add(player, unitPrefab);
                unit.transform.position = new Vector3(Random.Range(0.0f, 10.0f), 0.0f, Random.Range(0.0f, 10.0f));
            }
        }

    }
}
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Foes
{
    public class CircleFoeSpawner : MonoBehaviour
    {
        public Foe foePrefab;
        public float spawnEvery = 0.3f;
        public float circleRadius = 20;
        public int initialBurstSpawn = 3;

        void Start()
        {
            for (int i = 0; i < initialBurstSpawn; i++)
            {
                SpawnFoe();
            }

            if (spawnEvery > 0)
            {
                InvokeRepeating(nameof(SpawnFoe), 0, spawnEvery);
            }
        }

        private void SpawnFoe()
        {
            var rand = Random.insideUnitCircle.normalized * circleRadius;
            var pos = new Vector3(rand.x, 0.2f, rand.y);
            Instantiate(foePrefab, pos, Quaternion.identity);
        }
    }
}
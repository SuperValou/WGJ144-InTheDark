using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Foes
{
    public class PointsFoeSpawner : MonoBehaviour
    {
        public Foe foePrefab;

        public Transform[] spawnPoints;
        public AnimationCurve spawnPerSecondOverTime = new AnimationCurve(new Keyframe(0f, 0.1f, 0f, 0f), new Keyframe(60f, 1f, 0f, 0f));

        void Start()
        {
            if (spawnPoints.Length > 0)
            {
                StartCoroutine(SpawnRoutine());
            }
            else
            {
                Debug.LogWarning("No spawn point.");
            }
            
        }

        private IEnumerator SpawnRoutine()
        {
            while (this.gameObject != null)
            {
                float spawnFrequency = spawnPerSecondOverTime.Evaluate(Time.time);
                if (spawnFrequency <= 0)
                {
                    yield return null;
                }

                float timeToWait = 1f / spawnFrequency;
                yield return new WaitForSeconds(timeToWait);
                SpawnFoe();
            }
        }

        private void SpawnFoe()
        {
            Vector3 position = PickSpawnPoint();
            Instantiate(foePrefab, position, Quaternion.identity);
        }

        private Vector3 PickSpawnPoint()
        {
            int randomIndex = (int) (Random.value * spawnPoints.Length);
            return spawnPoints[randomIndex].position;
        }
    }
}
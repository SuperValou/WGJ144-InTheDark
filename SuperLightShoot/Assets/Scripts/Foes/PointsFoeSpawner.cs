using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Foes
{
    public class PointsFoeSpawner : MonoBehaviour
    {
        public Foe foePrefab;

        public Transform[] spawnPoints;
        public AnimationCurve spawnPerSecondOverTime = new AnimationCurve(new Keyframe(0f, 0.1f, 0f, 0f), new Keyframe(60f, 1f, 0f, 0f));

        //---
        private float _startOffset;

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

        void OnEnable()
        {
            _startOffset = Time.time;
        }

        private IEnumerator SpawnRoutine()
        {
            // allow the player to see the first foe coming from the gate in front of her
            Instantiate(foePrefab, spawnPoints.First().position, Quaternion.identity);
            yield return new WaitForSeconds(1);

            while (this.gameObject != null)
            {
                float spawnFrequency = spawnPerSecondOverTime.Evaluate(Time.time - _startOffset);
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
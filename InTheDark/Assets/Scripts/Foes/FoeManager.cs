using UnityEngine;

namespace Assets.Scripts.Foes
{
    public class FoeManager : MonoBehaviour
    {
        public Foe foePrefab;

        void Start()
        {
            SpawnFoe();
            SpawnFoe();
            SpawnFoe();
            InvokeRepeating(nameof(SpawnFoe), 0, 3);
        }

        private void SpawnFoe()
        {
            var rand = Random.insideUnitCircle * 20;
            var pos = new Vector3(Mathf.Max(5, rand.x), 2, Mathf.Max(5, rand.y));
            Instantiate(foePrefab, pos, Quaternion.identity);
        }
    }
}
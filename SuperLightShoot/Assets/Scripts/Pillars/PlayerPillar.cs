using Assets.Scripts.Foes;
using Assets.Scripts.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Pillars
{
    public class PlayerPillar : MonoBehaviour
    {
        public Transform player;

        void FixedUpdate()
        {
            player.transform.position = this.transform.position;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag != "Foe")
            {
                return;
            }

            var attackingFoe = collision.gameObject.GetComponent<Foe>();
            if (attackingFoe == null)
            {
                return;
            }

            attackingFoe.Kill();

            SceneManager.LoadScene(SceneIndexes.TitleScreenSceneIndex);
        }
    }
}
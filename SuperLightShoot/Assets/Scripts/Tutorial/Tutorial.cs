using Assets.Scripts.Foes;
using UnityEngine;

namespace Assets.Scripts.Tutorial
{
    public class Tutorial : MonoBehaviour
    {
        public GameObject tutorialText;
        public PointsFoeSpawner foeSpawner;

        void Awake()
        {
            tutorialText.gameObject.SetActive(true);
            foeSpawner.gameObject.SetActive(false);
        }

        void OnDestroy()
        {
            tutorialText.gameObject.SetActive(false);
            foeSpawner.gameObject.SetActive(true);
        }
    }
}
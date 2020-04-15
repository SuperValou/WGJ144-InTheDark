using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    public class MenuScript : MonoBehaviour
    {
        private AudioSource _audioSource;

        void Start()
        {
            _audioSource = this.GetOrThrow<AudioSource>();
        }

        public void StartGame()
        {
            _audioSource.Play();
            SceneManager.LoadScene(SceneIndexes.MainLevelSceneIndex);
        }

        public void GoToStartMenu()
        {
            _audioSource.Play();
            SceneManager.LoadScene(SceneIndexes.TitleScreenSceneIndex);
        }

        public void ExitGame()
        {
            _audioSource.Play();
            Application.Quit();
        }
    }
}
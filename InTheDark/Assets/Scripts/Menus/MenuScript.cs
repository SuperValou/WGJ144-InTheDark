using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menus
{
    public class MenuScript : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(SceneIndexes.MainLevelSceneIndex);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
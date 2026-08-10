using UnityEngine;

namespace Wizard
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;
        [SerializeField] private GameManager pauseMenu;

        private void Start()
        {
            inputReader.PauseEvent += HandlePause;
            inputReader.ResumeEvent += HandleResume;
        }

        private void HandlePause()
        {
            pauseMenu.gameObject.SetActive(true);
        }

        private void HandleResume()
        {
            pauseMenu.gameObject.SetActive(false);
        }
    }
}

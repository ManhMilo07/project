using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene: MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

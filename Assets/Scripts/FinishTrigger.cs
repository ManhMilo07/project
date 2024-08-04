using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Tìm GameManager trong cảnh và gọi phương thức LoadNextLevel
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.LoadNextLevel();
                Debug.Log("Player has reached the finish point!");
            }
            else
            {
                Debug.LogError("GameManager not found!");
            }
        }
    }
}

using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Treasure Figure"))
        {
            Time.timeScale = 0f;
            gameOverCanvas.SetActive(true);
        }
    }
}
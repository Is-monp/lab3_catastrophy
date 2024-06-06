using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game obj; // Singleton instance

    private void Awake()
    {
        if (obj == null)
        {
            obj = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void gameOver()
    {
        // Resetear el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

public class obstaculo : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cat_player"))
        {
            Game.obj.gameOver(); 
        }
    }
}

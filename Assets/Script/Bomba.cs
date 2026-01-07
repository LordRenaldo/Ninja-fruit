using UnityEngine;

public class Bomba : MonoBehaviour
{
    private GameManager gameManager;

    private void Start ()
    {
        gameManager = Object.FindFirstObjectByType<GameManager> ();
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if (collision.GetComponent<Espada> ())
        {
            gameManager.BombaTocada ();
        }
    }
}

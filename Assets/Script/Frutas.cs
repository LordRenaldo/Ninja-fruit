using UnityEngine;

public class Frutas : MonoBehaviour
{
    public GameObject prefabFrutaCortada;
    private GameManager gameManager;

    private void Awake ()
    {
        gameManager = Object.FindFirstObjectByType<GameManager> ();
    }

    public void CrearFrutaCortada ()
    {
        GameObject inst = Instantiate (prefabFrutaCortada, transform.position, transform.rotation);
        Rigidbody [] FrutasCortadas = inst.GetComponentsInChildren<Rigidbody> ();

        foreach (Rigidbody r in FrutasCortadas)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce (Random.Range (700, 1000), transform.position, 5f);
        }
        gameManager.aumentarPuntaje ();
        Destroy (inst, 8);
        Destroy (gameObject);
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if (collision.GetComponent<Espada> ())
        {
            CrearFrutaCortada ();
        }
    }
}

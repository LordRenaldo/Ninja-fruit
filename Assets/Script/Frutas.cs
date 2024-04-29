using UnityEngine;

public class Frutas : MonoBehaviour
{
    public GameObject prefabFrutaCortada;
    private Rigidbody2D espadaRigidbody;

    public void CrearFrutaCortada ()
    {
        GameObject inst = Instantiate (prefabFrutaCortada, transform.position, transform.rotation);
        Rigidbody[] FrutasCortadas = inst.GetComponentsInChildren<Rigidbody> ();

        foreach (Rigidbody r in FrutasCortadas)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce (Random.Range (700, 1000), transform.position, 5f);
        }
        Destroy (inst, 8);
        Destroy (gameObject);
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        Espada espada = collision.GetComponent<Espada> ();

        if (!espada)
        {
            return;
        }
        CrearFrutaCortada ();
    }

}

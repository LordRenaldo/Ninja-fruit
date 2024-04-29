using UnityEngine;

public class Espada : MonoBehaviour
{
    private Rigidbody2D filo;
    private Collider2D espada;

    // Start is called before the first frame update
    private void Awake ()
    {
        filo = GetComponent<Rigidbody2D> ();
        espada = GetComponent<Collider2D> ();
    }

    // Update is called once per frame
    void Update ()
    {
        AsociarEspadaAlMouse ();
    }

    private void AsociarEspadaAlMouse ()
    {
        var mousePosicion = Input.mousePosition;
        mousePosicion.z = 105;
        filo.position = Camera.main.ScreenToWorldPoint (mousePosicion);
        espada.transform.position = filo.position;
    }
}

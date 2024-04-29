using System.Collections;
using UnityEngine;

public class Arrojarfruta : MonoBehaviour
{
    public GameObject [] frutasArrojadas;
    public GameObject bomba;
    public float TiempoEsperaMinimo;
    public float TiempoEsperaMaximo;
    public float fuerzaMinima;
    public float fuerzaMaxima;
    public Transform [] lugaresDeLanzamiento;

    private Rigidbody2D frutaRigidbody;

    // Start is called before the first frame update
    void Start ()
    {
        StartCoroutine (ArrojadorDeFruta ());
    }

    private IEnumerator ArrojadorDeFruta ()
    {
        while (true)
        {
            yield return new WaitForSeconds (Random.Range (TiempoEsperaMinimo, TiempoEsperaMaximo));
            Transform t = lugaresDeLanzamiento [Random.Range (0, lugaresDeLanzamiento.Length)];
            GameObject go = Random.Range (0, 100) < 10 ? bomba : frutasArrojadas [Random.Range (0, frutasArrojadas.Length)];

            GameObject fruta = Instantiate (go, t.position, t.rotation);
            frutaRigidbody = fruta.GetComponent<Rigidbody2D> ();
            frutaRigidbody.AddForce (t.transform.up * Random.Range (fuerzaMinima, fuerzaMaxima), ForceMode2D.Impulse);
            Destroy (fruta, 8);
        }
    }
}

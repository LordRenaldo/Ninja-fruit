using System.Collections;
using UnityEngine;

public class Arrojarfruta : MonoBehaviour
{
    public GameObject frutaArrojada;
    public float TiempoEsperaMinimo;
    public float TiempoEsperaMaximo;
    public float fuerzaMinima;
    public float fuerzaMaxima;
    public Transform[] lugaresDeLanzamiento;

    // Start is called before the first frame update
    void Start ()
    {
        StartCoroutine (ArrojadorDeFruta ());
    }
    // Update is called once per frame
    void Update ()
    {

    }
    private IEnumerator ArrojadorDeFruta ()
    {
        while (true)
        {
            yield return new WaitForSeconds (Random.Range (TiempoEsperaMinimo, TiempoEsperaMaximo));
            Transform t = lugaresDeLanzamiento[Random.Range (0, lugaresDeLanzamiento.Length)];
            GameObject fruta = Instantiate (frutaArrojada, t.position, t.rotation);
            fruta.GetComponent<Rigidbody2D> ().AddForce (t.transform.up * Random.Range (fuerzaMinima, fuerzaMaxima), ForceMode2D.Impulse);
            Destroy (fruta, 8);
        }
    }
}

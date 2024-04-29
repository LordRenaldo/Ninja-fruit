using UnityEngine;

public class Controldesonidos : MonoBehaviour
{
    public AudioSource quienEmite;
    public AudioClip audioClip;
    public float volumen;
    private float lastPlayed;

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if (Time.time - lastPlayed > 0.1f)//para que no se repita el sonido
        {
            quienEmite.PlayOneShot (audioClip, volumen);
            lastPlayed = Time.time;
        }
    }
}

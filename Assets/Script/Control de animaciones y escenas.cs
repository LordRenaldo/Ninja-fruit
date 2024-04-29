using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controldeanimacionesyescenas : MonoBehaviour
{
    public AudioSource quienEmite1;
    public AudioSource quienEmite2;
    public AudioClip musica;
    public AudioClip inicio;

    private AudioSource [] audioSources;

    private void Start ()
    {
        audioSources = FindObjectsOfType<AudioSource> ();
    }

    public void CambioDeEscena ()
    {
        StartCoroutine (CambioDeEscenaConEspera ());
    }

    private IEnumerator CambioDeEscenaConEspera ()
    {
        DetenerSonido (quienEmite1);
        quienEmite1.PlayOneShot (inicio, 1);
        yield return new WaitForSeconds (3);
        SceneManager.LoadScene (1);
    }

    private void DetenerSonido ( AudioSource emisor )
    {
        foreach (AudioSource fuenteDeAudio in audioSources)
        {
            if (fuenteDeAudio != quienEmite2)
            {
                quienEmite1.Stop ();
            }
        }
    }
}

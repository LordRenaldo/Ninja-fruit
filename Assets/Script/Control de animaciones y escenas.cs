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
        // Reemplazo correcto de FindObjectsOfType (obsoleto)
        audioSources = Object.FindObjectsByType<AudioSource> (FindObjectsSortMode.None);
    }

    public void CambioDeEscena ()
    {
        StartCoroutine (CambioDeEscenaConEspera ());
    }

    private IEnumerator CambioDeEscenaConEspera ()
    {
        // Detiene todos los audios excepto quienEmite2 (por tu lógica original)
        DetenerSonido (quienEmite2);

        // Opcional: si querés asegurar que el emisor 1 arranque limpio
        if (quienEmite1 != null)
            quienEmite1.Stop ();

        if (quienEmite1 != null && inicio != null)
            quienEmite1.PlayOneShot (inicio, 1f);

        yield return new WaitForSeconds (3f);
        SceneManager.LoadScene (1);
    }

    private void DetenerSonido ( AudioSource excepto )
    {
        // Por si cambian audios en runtime, refrescamos si está vacío
        if (audioSources == null || audioSources.Length == 0)
            audioSources = Object.FindObjectsByType<AudioSource> (FindObjectsSortMode.None);

        foreach (AudioSource fuenteDeAudio in audioSources)
        {
            if (fuenteDeAudio == null) continue;
            if (fuenteDeAudio == excepto) continue;

            // BUG FIX: parar la fuente que estoy recorriendo
            fuenteDeAudio.Stop ();
        }
    }
}

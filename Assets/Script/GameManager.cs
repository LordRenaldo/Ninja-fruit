using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Elementos del puntaje")]
    private int puntajeNumero;
    public TextMeshProUGUI puntajeTexto;

    [Header ("Elementos del game over")]
    public GameObject panelGameOver;
    public TextMeshProUGUI puntajeFinal;

    [Header ("Elementos del mejor puntaje")]
    private int mejorPuntaje;
    public TextMeshProUGUI mejorPuntajeTexto;

    [SerializeField] private float tiempoMaximo;
    private float tiempoActual;
    bool tiempoActivo = false;

    [SerializeField] private Slider Slider;

    private GameObject [] interactivoObjects;

    public void Awake ()
    {
        panelGameOver.SetActive (false);

        puntajeNumero = 0;
        puntajeTexto.text = "Puntaje: 0";
        puntajeFinal.text = "Puntaje: 0";

        mejorPuntaje = PlayerPrefs.GetInt ("Mejor puntaje", 0);
        ActualizarMejorPuntajeTexto ();

        interactivoObjects = GameObject.FindGameObjectsWithTag ("Interactivo");
    }
    public void Start ()
    {
        ActivarContador ();
    }
    public void Update ()
    {
        if (tiempoActivo)
        {
            CambiarContador ();
        }

    }

    public void aumentarPuntaje ()
    {
        puntajeNumero++;
        puntajeTexto.text = "Puntaje: " + puntajeNumero;

        if (puntajeNumero > mejorPuntaje)
        {
            mejorPuntaje = puntajeNumero;
            PlayerPrefs.SetInt ("Mejor puntaje", mejorPuntaje);
            ActualizarMejorPuntajeTexto ();
        }
    }

    private void ActualizarMejorPuntajeTexto ()
    {
        mejorPuntajeTexto.text = "Mejor puntaje: " + mejorPuntaje;
    }

    public void BombaTocada ()
    {
        Debug.Log ("bomba tocada");
        Time.timeScale = 0;
        panelGameOver.SetActive (true);
        puntajeFinal.text = "Puntaje: " + puntajeNumero;
    }

    public void JugarOtravez ()
    {
        ActivarContador ();
        puntajeNumero = 0;
        puntajeTexto.text = puntajeNumero.ToString ();
        puntajeFinal.text = puntajeNumero.ToString ();
        Time.timeScale = 1;
        panelGameOver.SetActive (false);
        foreach (GameObject gameObject in interactivoObjects)
        {
            Destroy (gameObject);
        }
    }
    private void CambiarContador ()
    {
        tiempoActual -= Time.deltaTime;
        if (tiempoActual >= 0)
        {
            Slider.value = tiempoActual;

        }
        if (tiempoActual <= 0)
        {
            BombaTocada ();
            CambiarTemporizador (false);

        }
    }
    private void CambiarTemporizador ( bool estado )
    {
        tiempoActivo = estado;

    }
    private void ActivarContador ()
    {
        tiempoActual = tiempoMaximo;
        Slider.value = tiempoMaximo;
        CambiarTemporizador (true);
    }
    private void DesactivarTemporizador ()
    {
        CambiarTemporizador (false);
    }
}

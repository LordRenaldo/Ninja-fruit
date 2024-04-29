using UnityEngine;

public class Espada : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake ()
    {
        mainCamera = Camera.main;
    }

    void Update ()
    {
        AsociarEspadaMouse ();
    }

    private void AsociarEspadaMouse ()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 80;
        transform.position = mainCamera.ScreenToWorldPoint (mousePosition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScamera : MonoBehaviour
{
    private float mouseX; // Bewegen der Maus entlang der x-Achse
    private float mouseY; // Bewegen der Maus entlang der Y-Achse

    [Header("×óâñòâèòåëüíîñòü ìûøè")]
    public float sensivityMouse = 200f; // mausgeschwindigkeit

    public Transform Player;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Entfernen Sie den Cursor von der Kamera
    }


    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime;
        mouseY= Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime;

        Player.Rotate(mouseX * new Vector3(0, 1, 0)); // Kameradrehung X-Achse

        transform.Rotate(-mouseY * new Vector3(1, 0, 0)); // Kameradrehung Y-Achse
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScamera : MonoBehaviour
{
    private float mouseX; // Перемещение мыши по оси Х \\ Moving the mouse along the X axis
    private float mouseY; // Перемещение мыши по оси Y \\ Moving the mouse along the Y axis

    [Header("Чувствительность мыши")]
    public float sensivityMouse = 200f; // mouse speed

    public Transform Player;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Убрать курсор с камеры \\ Remove the cursor from the camera
    }


    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime;
        mouseY= Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime;

        Player.Rotate(mouseX * new Vector3(0, 1, 0)); // Поворот камеры ось Х \\ Camera rotation X axis

        transform.Rotate(-mouseY * new Vector3(1, 0, 0)); // Поворот камеры ось Y \\ Camera rotation Y axis
    }
}

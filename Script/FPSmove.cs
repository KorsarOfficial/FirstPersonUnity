using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmove : MonoBehaviour
{
    [Header("Скорость перемещения персонажа")]
    private float speed = 7f; // Настройте начальную скорость перемещения персонажа \\ Adjust the initial speed of the character's movement
    public float runSpeed = 8.5f; // Настройте бег персонажа \\ Customize your character's running
    public float jumpPower = 200f; // Настройте силу прыжка персонажа \\ Adjust your character's jump power
    [Header("На земле ли игрок")]
    public bool ground; // проверка коллизии персонажа. Находится ли он земле \\ checking for a character collision. Is it on the ground
    public Rigidbody rb;

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift)) // отвечает за бег \\ responsible for running
            {
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime;
            }
            else // отвечает за перемещение вперёд \\ responsible for movement forward
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S)) // перемещение назад \\ moving backwards
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) // перемещение влево \\ moving to the left
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) // перемещение вправо \\ moving to the right
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space)) // прыжок \\ jump
        {
            if(ground == true)
            {
                rb.AddForce(transform.up * jumpPower); 
            }
        }
    }
    private void OnCollisionEnter(Collision collision) // проверка коллизии Вход \\ checking the Input collision
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }

    }
    private void OnCollisionExit(Collision collision) // проверка коллизии Выход \\ Collision check Output
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }

}

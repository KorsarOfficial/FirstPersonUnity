using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmove : MonoBehaviour
{
    [Header("Ñêîðîñòü ïåðåìåùåíèÿ ïåðñîíàæà")]
    private float speed = 7f; // Passen Sie die Anfangsgeschwindigkeit der Bewegung des Charakters an
    public float runSpeed = 8.5f; // Passen Sie den Lauf Ihres Charakters an
    public float jumpPower = 200f; // Passen Sie die Sprungkraft Ihres Charakters an
    [Header("Íà çåìëå ëè èãðîê")]
    public bool ground; // überprüfung auf eine Zeichenkollision. Ist es auf dem Boden
    public Rigidbody rb;

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift)) // verantwortlich für das Laufen
            {
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime;
            }
            else // verantwortlich für die Vorwärtsbewegung
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S)) // rückwärts bewegen
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) // nach links bewegen
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) // nach rechts bewegen
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space)) // Spring
        {
            if(ground == true)
            {
                rb.AddForce(transform.up * jumpPower); 
            }
        }
    }
    private void OnCollisionEnter(Collision collision) // überprüfung der Eingabekollision
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }

    }
    private void OnCollisionExit(Collision collision) // Ausgabe der Kollisionsprüfung
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }

}

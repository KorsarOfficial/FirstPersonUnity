using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmove : MonoBehaviour
{
    [Header("�������� ����������� ���������")]
    private float speed = 7f; // ��������� ��������� �������� ����������� ��������� \\ Adjust the initial speed of the character's movement
    public float runSpeed = 8.5f; // ��������� ��� ��������� \\ Customize your character's running
    public float jumpPower = 200f; // ��������� ���� ������ ��������� \\ Adjust your character's jump power
    [Header("�� ����� �� �����")]
    public bool ground; // �������� �������� ���������. ��������� �� �� ����� \\ checking for a character collision. Is it on the ground
    public Rigidbody rb;

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift)) // �������� �� ��� \\ responsible for running
            {
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime;
            }
            else // �������� �� ����������� ����� \\ responsible for movement forward
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S)) // ����������� ����� \\ moving backwards
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) // ����������� ����� \\ moving to the left
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) // ����������� ������ \\ moving to the right
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space)) // ������ \\ jump
        {
            if(ground == true)
            {
                rb.AddForce(transform.up * jumpPower); 
            }
        }
    }
    private void OnCollisionEnter(Collision collision) // �������� �������� ���� \\ checking the Input collision
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }

    }
    private void OnCollisionExit(Collision collision) // �������� �������� ����� \\ Collision check Output
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }

}

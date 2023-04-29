using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 500.0f;

    [SerializeField] private Camera camera_;
    private Vector3 offsetWithCamera;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offsetWithCamera = transform.position - camera_.transform.position;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("LeftPlayerHorizontal");
        float moveVertical = Input.GetAxis("LeftPlayerVertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
    }

    void LateUpdate() {
        transform.position = camera_.transform.position + offsetWithCamera;
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
}

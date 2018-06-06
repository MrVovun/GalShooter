using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        float veticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * speed * veticalInput);

        if (transform.position.y > 4.3f)
        {
            transform.position = new Vector3(transform.position.x, 4.3f, 0);
        }
        else if (transform.position.y < -4.3f)
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0);
        }

        if (transform.position.x > 8.2f)
        {
            transform.position = new Vector3(8.2f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.2f)
        {
            transform.position = new Vector3(-8.2f, transform.position.y, 0);
        }
    }

}

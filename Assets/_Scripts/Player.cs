using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject laserPrefab;
    public float firerate;
    private float _nextFire = 0.0f;

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

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

    private void Shoot()
    {
        if (Time.time > _nextFire)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1.13f, 0), Quaternion.identity);
            _nextFire = Time.time + firerate;
        }
    }

}

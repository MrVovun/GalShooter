using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShot = false;
    public bool speedBoostOn = false;
    public float speed;
    public GameObject laserPrefab;
    public GameObject triLaserPrefab;
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
        float veticalInput = Input.GetAxis("Vertical");

        if (speedBoostOn == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * 2.0f * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * 2.0f * veticalInput);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * veticalInput);
        }

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
            if (canTripleShot == true)
            {
                Instantiate(triLaserPrefab, transform.position + new Vector3(0, 1.13f, 0), Quaternion.identity);
                _nextFire = Time.time + firerate;
            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.13f, 0), Quaternion.identity);
                _nextFire = Time.time + firerate;
            }
        }
    }

    public void TripleShotOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedBoostOn()
    {
        speedBoostOn = true;
        StartCoroutine(SpeedBoostRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    public IEnumerator SpeedBoostRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speedBoostOn = false;
    }

}

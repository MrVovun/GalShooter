using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed;

	void Start ()
    {
		
	}
	
	void Update () { 
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > 10)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (transform.parent != null)
        {
            if (transform.parent.childCount == 1)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}

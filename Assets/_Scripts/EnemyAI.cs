using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float speed;
	
	void Start ()
    {

	}
	
	
	void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < -8)
        {
            float randomX = Random.Range(-6, 6);
            transform.position = new Vector3(randomX, 8, 0);
        }
    }
}

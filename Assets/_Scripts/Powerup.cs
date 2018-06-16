using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private int powerupID;

	void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player _player = other.GetComponent<Player>();
            if (_player != null)

            {
                if (powerupID == 0)
                {
                    _player.TripleShotOn();
                }
                else if (powerupID == 1)
                {
                    _player.SpeedBoostOn();
                }
                else if (powerupID == 2)
                {

                }
            }

           

            Destroy(this.gameObject);
        }
    }
}

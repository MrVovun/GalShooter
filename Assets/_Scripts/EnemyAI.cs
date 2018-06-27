using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float speed;
    public GameObject DeathAnim;

    private UIManager _uiManager;
    private GameManager _gameManager;
    [SerializeField]
    private AudioClip _clip;

    void Start ()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < -8)
        {
            if (_gameManager.gameOver == true)
            {
                Destroy(this.gameObject);
            }
            float randomX = Random.Range(-6, 6);
            transform.position = new Vector3(randomX, 8, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(DeathAnim, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
            Destroy(this.gameObject);

            if (_uiManager != null)
            {
                _uiManager.UpdateScore();
            }
        }
    }
}

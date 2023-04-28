using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    public Rigidbody2D body;
    public AudioClip sound;
    public Transform camera;
    private float delay = 2f;
    private bool iniciado = false;
    void Start()
    {

    }
    void Update()
    {
        delay -= Time.deltaTime;
        if ((delay <= 0 || (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))) && !iniciado)
        {
            iniciado = true;
            int direction = Random.Range(0, 4);
            Vector2 vector;
            switch (direction)
            {
                case 0:
                    vector.x = 5f;
                    vector.y = 5f;
                    break;           
                case 1:
                    vector.x = -5f;
                    vector.y = 5f;
                    break;           
                case 2:
                    vector.x = -5f;
                    vector.y = -5f;
                    break;           
                default:
                    vector.x = 5f;
                    vector.y = +5f;
                    break;
            }
            body.velocity = vector;
        }
        
        if (transform.position.x < -12.03f || transform.position.x > 12.03f)
        {
            SceneManager.LoadScene("Table");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(sound, camera.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 15f;
    [SerializeField] GameOverScript gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pipe") ||
            collision.gameObject.CompareTag("Ground"))
        {
            StateController.isGameOver = true;
            Time.timeScale = 0;
            gameOverScreen.gameObject.SetActive(true);
            gameOverScreen.displayGameOver();
        }
    }
}

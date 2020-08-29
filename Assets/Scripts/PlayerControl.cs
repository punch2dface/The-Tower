using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    bool isGrounded = false;

    Vector3 dragStartPos;
    Touch touch;
    Vector3 lastVelocity;

    public GameObject gameOverWindow;
    public PlayerControl pc;
    public GameObject pauseBtn;
    public GameObject victoryCanvas;


    private void Update()
    {
        if (isGrounded)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        DragStart();
                        break;
                    case TouchPhase.Moved:
                        Dragging();
                        break;
                    case TouchPhase.Ended:
                        DragRelease();
                        break;
                }
            }
        }

        lastVelocity = rb.velocity;
        
    }

    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }
    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }
    void DragRelease()
    {
        lr.positionCount = 0;
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;
        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Goal"))
        {
            if(collision.gameObject.CompareTag("Goal"))
            {
                Debug.Log("Winner");
                // Enable Winner Canvas with buttons and shit

                Time.timeScale = 0f;
                victoryCanvas.SetActive(true);
                pauseBtn.SetActive(false);
                pc.enabled = false;

            }
            isGrounded = true;
            Debug.Log("isGrounded: " + isGrounded);
        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Bottom Ground"))
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Goal"))
        {
            isGrounded = false;
            Debug.Log("isGrounded: " + isGrounded);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Death Collider")
        {
            Time.timeScale = 0f;
            gameOverWindow.SetActive(true);
            pauseBtn.SetActive(false);
            pc.enabled = false;
        }
    }
}

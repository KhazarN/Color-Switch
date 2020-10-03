using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;

    public Color colorCyan;
    public Color colorPink;
    public Color colorYellow;
    public Color colorMagenta;

    private void Start()
    {
        SetRandomColor();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }
        if (col.tag!=currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Game over!!!");
        }
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void SetRandomColor()
    {
        int rnumber = Random.Range(0, 4);

        switch (rnumber)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;

        }


    }
}

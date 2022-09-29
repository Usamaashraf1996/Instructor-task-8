using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float speed = 6f;
    public Animator playerAnim;
    public Vector3 eulerAngles;
    private Rigidbody2D rb;
    private SpawnManager spawnManager;
    public static int Score;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnManager=GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        playerAnim = GetComponent<Animator>();

    }
    private void Update()
    {


         float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow) && spawnManager.isGameActive )
        {
            transform.eulerAngles = new Vector2(0, 0);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            playerAnim.SetTrigger("Run");

        }
        else
       if (Input.GetKey(KeyCode.LeftArrow) &&spawnManager.isGameActive)
        {
           transform.eulerAngles = new Vector2(0, 180);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            playerAnim.SetTrigger("Run");


        }
        if (Input.GetKey(KeyCode.Space)&&spawnManager.isGameActive) {

            rb.AddForce(Vector2.up*2, ForceMode2D.Impulse);
            playerAnim.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("White"))
        {
            Destroy(collision.gameObject);
            spawnManager.updatescore(+3);
        }
        else if (collision.gameObject.CompareTag("Green"))
        {
            Destroy(collision.gameObject);
            spawnManager.updatescore(+5);
        }
        else if (collision.gameObject.CompareTag("Red")) {
            Destroy(collision.gameObject);
            spawnManager.updatescore(-10);
        }
    }




}
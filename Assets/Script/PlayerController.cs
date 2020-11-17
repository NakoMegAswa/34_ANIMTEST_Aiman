using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    bool collide;
    int enemyHP = 0;
    public GameObject Enemy;
    public bool isOnPlayPlane;
    public float health;

    bool canMove = true;

    public GameObject healthText;

    public Rigidbody playerRb;
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        //playerAnim = GetComponent<Animator>(); not needed lmao
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("isMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                playerAnim.SetBool("isMove", false);
            }

            //if (Input.GetKeyDown(KeyCode.Space))
            //  {
            //    playerAnim.SetTrigger("TrigAttack");
            // }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("isMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("isMove", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("isMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                playerAnim.SetBool("isMove", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("isMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetBool("isMove", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnPlayPlane)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnim.SetTrigger("trigFlip");
                isOnPlayPlane = false;

           
            }
        }
      

        if(Input.GetKeyDown(KeyCode.K))
        {
            health -= 1;
            healthText.GetComponent<Text>().text = "Health: " + health;

            if (health <= 0)
            {
                canMove = false;
                playerAnim.SetTrigger("trigDeath");
            }
        
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayPlane"))
        {
            isOnPlayPlane = true;
        }

    }

    


}


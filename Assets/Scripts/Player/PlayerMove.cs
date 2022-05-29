using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public GameManager gameManager;
    public float moveSpeed = 3f;
    public float leftRightSpeed = 4f;
    public float jumpSpeed = 40f;
    public Transform particlePos;
    

    private Rigidbody rb;
    private bool isOnGround = true;
   
    
   void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        
    }
    void Update()
    {
        if (GameManager.instance.gameHasEnded || !GameManager.instance.gameStarted)
            return;
        transform.Translate(Vector3.forward * moveSpeed*Time.deltaTime,Space.World);

        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround)
        {            
            rb.AddForce(Vector3.up*jumpSpeed ,ForceMode.Impulse);
            isOnGround = false;
            transform.GetComponent<Animator>().SetTrigger("Jump");
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundaries.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(this.gameObject.transform.position.x < LevelBoundaries.rightSide)
            {
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
            
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            isOnGround = true;
            
        }
        if(collision.transform.tag == "Obstacle")
        {
             GameObject particle = Instantiate(GameManager.instance.particlePrefab);
             particle.transform.position = particlePos.position;
             transform.GetComponent<Animator>().SetBool("Death", true);
            GameManager.instance.EndGame();
        }
    }
}

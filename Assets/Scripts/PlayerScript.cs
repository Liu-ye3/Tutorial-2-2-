/* 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text WinText;
    private int lifeValue = 3;
    public Text Lives;
    //ground
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    //sound
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    //animation
    Animator anim;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Score: " + scoreValue.ToString();
        WinText.text = "";
        Lives.text = "Lives: " + lifeValue.ToString(); //"lives has text that is the same the string of lifeValue
        //sound
        musicSource.clip = musicClipOne;
        musicSource.loop = true;
        musicSource.Play();
        //animation
        anim = GetComponent<Animator>();
    }
    void Update(){
        //change state based on key press
        if ((Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.RightArrow))) {
             anim.SetInteger("move_state", 2);
        }       

        if ((Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.LeftArrow))) {
             anim.SetInteger("move_state", 2);
        }   
    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //ground/jump
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);
        //movement
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        //flip
        if (facingRight == false && hozMovement > 0){
            Flip();
        } else if (facingRight == true && hozMovement < 0){
            Flip();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if (scoreValue == 4) {
                lifeValue = 3;
                Lives.text = "Lives: " + lifeValue.ToString();
                transform.position = new Vector2(28.0f, 4.0f);
            }
            if (scoreValue >= 8) {
                WinText.text = "You Win! Game by Taylor Torres.";
                musicSource.Stop();
                musicSource.clip = musicClipTwo;
                musicSource.loop = false;
                musicSource.Play();
                }
        }
        if (collision.collider.tag == "Enemy")
        {
            lifeValue -= 1;
            Lives.text = "Lives: " + lifeValue.ToString();
            Destroy(collision.collider.gameObject);
            if (lifeValue <= 0) {
                Destroy(this);
                WinText.text = "You Lose! Game by Taylor Torres.";
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
            {
                if ((Input.GetKey(KeyCode.W))||(Input.GetKey(KeyCode.UpArrow)))
                    {
                        rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                        anim.SetInteger("move_state", 3);
                    } else { anim.SetInteger("move_state", 0);}
            }  
    } 

    void Flip() //flip is a function
   {
     facingRight = !facingRight;
     Vector2 Scaler = transform.localScale;
     Scaler.x = Scaler.x * -1;
     transform.localScale = Scaler;
   }

}*/

//this version seems to work better. no running animation plays while jumping
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text WinText;
    private int lifeValue = 3;
    public Text Lives;
    //ground
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    //sound
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    //animation
    Animator anim;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Score: " + scoreValue.ToString();
        WinText.text = "";
        Lives.text = "Lives: " + lifeValue.ToString(); //"lives has text that is the same the string of lifeValue
        //sound
        musicSource.clip = musicClipOne;
        musicSource.loop = true;
        musicSource.Play();
        //animation
        anim = GetComponent<Animator>();
    }
    void Update(){
        //change state based on key press
        // if ((Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.RightArrow))) {
        //      anim.SetInteger("move_state", 2);
        // }       

        // if ((Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.LeftArrow))) {
        //      anim.SetInteger("move_state", 2);
        // }   
    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //ground/jump
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);
        //movement
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        //flip
        if (facingRight == false && hozMovement > 0){
            Flip();
        } else if (facingRight == true && hozMovement < 0){
            Flip();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if (scoreValue == 4) {
                lifeValue = 3;
                Lives.text = "Lives: " + lifeValue.ToString();
                transform.position = new Vector2(28.0f, 4.0f);
            }
            if (scoreValue >= 8) {
                WinText.text = "You Win! Game by Taylor Torres.";
                musicSource.Stop();
                musicSource.clip = musicClipTwo;
                musicSource.loop = false;
                musicSource.Play();
                }
        }
        if (collision.collider.tag == "Enemy")
        {
            lifeValue -= 1;
            Lives.text = "Lives: " + lifeValue.ToString();
            Destroy(collision.collider.gameObject);
            if (lifeValue <= 0) {
                Destroy(this);
                WinText.text = "You Lose! Game by Taylor Torres.";
            }
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float hozMovement = Input.GetAxis("Horizontal");
        if (collision.collider.tag == "Ground" && isOnGround)
            {
                if((hozMovement != 0) && (isOnGround)){
                    anim.SetInteger("move_state", 2);
                    } else {anim.SetInteger("move_state", 0);}
                if ((Input.GetKey(KeyCode.W))||(Input.GetKey(KeyCode.UpArrow)))
                    {
                        rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                        anim.SetInteger("move_state", 3);
                    } //else { anim.SetInteger("move_state", 0);}
            }  
    } 

    private void OnCollisionExit2D(Collision2D collision){
         float hozMovement = Input.GetAxis("Horizontal");
             if (collision.collider.tag == "Ground"){
                
                    
                
             } 
    }
    void Flip() //flip is a function
   {
     facingRight = !facingRight;
     Vector2 Scaler = transform.localScale;
     Scaler.x = Scaler.x * -1;
     transform.localScale = Scaler;
   }

}
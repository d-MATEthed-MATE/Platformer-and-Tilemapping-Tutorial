using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb;
    
    public Text lives;
    private int livesValue = 3;
    
    
    public GameObject winTextObject;
    
    public GameObject loseTextObject;

     private Rigidbody2D rd2d;

     public float speed;
     public Text score;
     private int scoreValue = 0;
     Animator anim;
     private bool facingRight = true;
     public AudioSource musicSource;
    private Animator animator;
     public AudioClip musicClipOne;

     
       
     
     
    
     
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();
        
        score.text = scoreValue.ToString();
        anim = GetComponent<Animator>();
        lives.text = livesValue.ToString();
       
       SetScoreText();
       winTextObject.SetActive(false);

       SetLivesText();
       loseTextObject.SetActive(false);

        
        rd2d = GetComponent<Rigidbody2D>();
        
       
        
    }

    
    void SetScoreText()
    {
        
    }

    void SetLivesText()
    {
       
    }


    void Flip()
   {
     facingRight = !facingRight;
     Vector2 Scaler = transform.localScale;
     Scaler.x = Scaler.x * -1;
     transform.localScale = Scaler;
   }

    void SetscoreValueText()
    {
        score.text = "Score: " + score.ToString();
    }

    void SetlivesValueText()
    {
        lives.text = "Lives: " + score.ToString();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        
        if (facingRight == false && hozMovement > 0)
   {
     Flip();
   }
else if (facingRight == true && hozMovement < 0)
   {
     Flip();
   }    
       if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))

        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 2);
        }     
        }
        
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
           Destroy(collision.collider.gameObject);

           if (scoreValue == 4)
           {
            transform.position = new Vector2(39.59f, 0.46f);
            
            livesValue = 3;
            lives.text = livesValue.ToString();
           }


           if (scoreValue == 8)
           {
            musicSource.clip = musicClipOne;
            musicSource.Play();
            winTextObject.SetActive(true);
            speed = 0;
           }
            
           
        }

        if (collision.collider.tag == "Enemy") 
        {
           livesValue -= 1; 
           lives.text = livesValue.ToString();
           Destroy(collision.collider.gameObject); 

           if (livesValue == 0)
            {
                loseTextObject.SetActive(true);
                speed = 0;
            }
        }     

    }
      private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {

            if (Input.GetKey(KeyCode.W))
        {
        rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); 
        }

        
    }

    }


}


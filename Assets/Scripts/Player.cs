using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movmentX;

    private Rigidbody2D myBody;
    private Animator anim;
    private string WALK_ANIMATION = "Walk"; 
    private SpriteRenderer sr;

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    
    private string Enemy_TAG = "Enemy";

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate() {
        PlayerJump();    
    }

    void PlayerMoveKeyboard(){

        movmentX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movmentX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer(){

        //player moving to right side
        if (movmentX > 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }

        //player moving to left side
        else if (movmentX < 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }

        else{
            anim.SetBool(WALK_ANIMATION, false);
        }   
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(Enemy_TAG)){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag(Enemy_TAG)){
            Destroy(gameObject);
        }
    }
}

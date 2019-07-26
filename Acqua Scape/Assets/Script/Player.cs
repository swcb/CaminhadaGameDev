using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
        //Variaveis globais
    private Rigidbody2D     playerRb;
    private SpriteRenderer  playerSprite;
    public  float           velocidade;
    public  bool            flipX;
    
        // Start is called before the first frame update
    void Start(){
        
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();

    }

        // Update is called once per frame
    void Update(){

        if(Input.GetMouseButtonDown(0)){
            velocidade *= -1;
            flipX = !flipX;
            playerSprite.flipX = flipX;
        }

        playerRb.velocity = new Vector2(velocidade, playerRb.velocity.y); //ou (velocidade, playerRb.velocity.y)

    }

    void OnCollisionEnter2D(Collision2D colisao) {
        if(colisao.gameObject.tag == "Parede") {
            SceneManager.LoadScene("morreu");
        }
    }

    void OnTriggerEnter2D(Collider2D colisao) {
        if(colisao.gameObject.tag == "Gota") {
            SceneManager.LoadScene("morreu");
        }
    }

}

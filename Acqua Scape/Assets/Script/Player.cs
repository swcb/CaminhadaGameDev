using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
        //Variaveis globais
    private Rigidbody2D     playerRb;
    private SpriteRenderer  playerSprite;
    public  float           velocidadeMax;
    public  float           velocidadeMin;
    public  float           velocidadeAtual;
    public  float           aceleracao;
    public  bool            flipX;
        
        //test
    public GameObject outroGameObject;
    private ScriptTest outroScript;
    private ScriptTest maisOutroScript;
    
    void Start(){
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        velocidadeAtual = velocidadeMax;
            //test
        //outroScript = GetComponent<ScriptTest>();
        maisOutroScript = outroGameObject.GetComponent<ScriptTest>();
        //print("outroScript: " + outroScript.name + " " + outroScript.idade);
        print("maisOutroScript: " + maisOutroScript.nome + " " + maisOutroScript.idade);

    }

        // Update is called once per frame
    void Update(){
        

        /*
            if(Input.GetMouseButtonDown(0)){
                velocidade *= -1;
                flipX = !flipX;
                playerSprite.flipX = flipX;
            }
        
        float movimento = Input.GetAxis("Horizontal");
        if(movimento > 0){
            velocidadeAtual = (Math.Abs(velocidadeAtual) + velocidadeMin) * movimento * aceleracao;
            if(velocidadeAtual > velocidadeMax) velocidadeAtual = velocidadeMax;
        }
        else if(movimento < 0){
            velocidadeAtual = (Math.Abs(velocidadeAtual) + velocidadeMin) * movimento * aceleracao;
            if(velocidadeAtual < (-1 * velocidadeMax)) velocidadeAtual = -1 * velocidadeMax;
        }
        else 
            velocidadeAtual = 0;   

        */
        if(Math.Abs(velocidadeAtual) < velocidadeMax){
            velocidadeAtual *= aceleracao;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            //velocidadeAtual = -1 * (velocidadeMin * 1/velocidadeAtual + velocidadeMin);
            if (velocidadeAtual > 0) velocidadeAtual = velocidadeMin * -1;
            else if (velocidadeAtual < 0) velocidadeAtual = velocidadeMin;
            flipX = !flipX;
            playerSprite.flipX = flipX;
        }

        playerRb.velocity = new Vector2(velocidadeAtual, playerRb.velocity.y); //ou (velocidade, playerRb.velocity.y)

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

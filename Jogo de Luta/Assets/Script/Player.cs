using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    
    private Rigidbody2D     playerRb;
    private Animator        playerAn;
    public  float           velocidadeMax;
    public  float           velocidadeInicial;
    public  float           velocidadeAtual;
    public  float           aceleracao;
    public  float           desaceleracao;
    public  float           forcaSalto;
    private float           jump = 0;
    public  bool            isJumping = false;    
    public  bool            inAttacking;
    public  bool            inBlocking;


    void Start(){
        playerRb = GetComponent<Rigidbody2D>();
        playerAn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
            //Movimento
        float movimento = Input.GetAxis("Horizontal");
        if(movimento > 0){
            velocidadeAtual = (Math.Abs(velocidadeAtual) + velocidadeInicial) * movimento * aceleracao;
            if(velocidadeAtual > velocidadeMax) velocidadeAtual = velocidadeMax;
        }
        else if(movimento < 0){
            velocidadeAtual = (Math.Abs(velocidadeAtual) + velocidadeInicial) * movimento * aceleracao;
            if(velocidadeAtual < (-1 * velocidadeMax)) velocidadeAtual = -1 * velocidadeMax;
        }
        else {
            if(velocidadeAtual > 0.5) {
                velocidadeAtual = velocidadeAtual - desaceleracao;
                if (velocidadeAtual < 0) velocidadeAtual = 0;
            } else if(velocidadeAtual < -0.5) {
                velocidadeAtual = velocidadeAtual + desaceleracao;
                if (velocidadeAtual > 0) velocidadeAtual = 0;
            } else
                velocidadeAtual = 0;
        }
        playerRb.velocity = new Vector2(velocidadeAtual, playerRb.velocity.y);
        if(velocidadeAtual == 0)
            playerAn.SetBool("isStopped", true);
        else
            playerAn.SetBool("isStopped", false);

            
            //Salto
        jump = Input.GetAxis("Jump");
        /*if(isJumping){
            jump = jump - playerRb.gravityScale;
            if (jump <= 0) jump = 0;
            playerRb.AddForce(Vector3.up * jump);
        }*/
        if(!isJumping && jump > 0){
            //jump = Input.GetAxis("Jump") * forcaSalto;
            isJumping = true;
            playerAn.SetBool("inGround", false);
            playerRb.AddForce(Vector3.up * forcaSalto);
        }

            //Ataque
        float ataque = Input.GetAxis("Attack");
        if(!inBlocking && !inAttacking && ataque > 0){
            inAttacking = true;
            playerAn.SetTrigger("Attacking");
        } else if(inAttacking && ataque == 0) {
            inAttacking = false;
        }
            //Bloqueando
        float bloque = Input.GetAxis("Block");
        if(bloque > 0){
            inBlocking = true;
            playerAn.SetTrigger("Blocking");
        } else {
           inBlocking = false;
        }
    }

    void OnCollisionEnter2D(Collision2D colisao){
        if (colisao.gameObject.tag == "ground" || colisao.gameObject.tag == "platform"){
            isJumping = false;
            playerAn.SetBool("inGround", true);
        }
    }

    void OnCollisionExit2D(Collision2D colisao){
        if (colisao.gameObject.tag == "ground" || colisao.gameObject.tag == "platform"){
            isJumping = true;
            playerAn.SetBool("inGround", false);
        }
    }
}

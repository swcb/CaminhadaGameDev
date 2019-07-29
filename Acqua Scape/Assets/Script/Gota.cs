using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gota : MonoBehaviour
{

    private     Rigidbody2D     gotaRb;
    private     Animator        gotaAnimator;
    private     float           atrito;
    public      float           atritoMax;
    public      Vector3         posicao;
    public      GameObject      gotaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
        gotaRb = GetComponent<Rigidbody2D>();
        gotaAnimator = GetComponent<Animator>();
        gotaRb.gravityScale = 15;
        atrito = Random.Range(3, atritoMax);
        gotaRb.drag = atrito;
        posicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D colisao) {
        if(colisao.gameObject.tag == "Chao" || colisao.gameObject.tag == "Player") {
            gotaRb.gravityScale = 0;
            gotaAnimator.SetBool("colidiu", true);
        }
    }*/

    void OnBecameInvisible() {
        Instantiate(gotaPrefab, posicao, transform.localRotation);
        Destroy(this.gameObject);
        pontuacao.pontos += 1;
    }
}

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
    public      GameObject      gotaDesfazendoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gotaRb = GetComponent<Rigidbody2D>();
        gotaRb.gravityScale = 15;
        atrito = Random.Range(3, atritoMax);
        gotaRb.drag = atrito;
        posicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colisao) {
        pontuacao.pontos += 1;
        Instantiate(gotaDesfazendoPrefab, transform.position, transform.localRotation);
        //Instantiate(gotaPrefab, posicao, transform.localRotation);
        //Destroy(this.gameObject);
        this.transform.position = posicao;
        this.gameObject.SetActive(false);
    }

    /*void OnBecameInvisible() {
        
        Instantiate(gotaPrefab, posicao, transform.localRotation);
        Destroy(this.gameObject);
        pontuacao.pontos += 1;
    }*/
}

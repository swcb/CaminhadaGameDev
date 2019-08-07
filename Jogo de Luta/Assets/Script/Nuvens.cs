using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvens : MonoBehaviour
{
    private     Rigidbody2D     nuvemRB;
    private     Transform       nuvemTr;
    public      float           veloMax;
    public      float           veloMin;
    public      float           velo;
    private     Vector3         posicaoInicial;

    // Start is called before the first frame update
    void Start(){
        nuvemRB = GetComponent<Rigidbody2D>();
        nuvemTr = GetComponent<Transform>();
        nuvemRB.gravityScale = 0;
        velo = Random.Range(veloMin, veloMax);
        nuvemRB.velocity =  new Vector2(-velo, 0);
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update(){ 
        if(transform.position.x < -11){
            velo = Random.Range(veloMin, veloMax);
            nuvemRB.velocity =  new Vector2(-velo, 0);
            this.transform.position = posicaoInicial;

        }
    }


}

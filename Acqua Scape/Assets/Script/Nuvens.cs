using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvens : MonoBehaviour
{
    private     Rigidbody2D     nuvemRB;
    public      float           veloMax;
    public      float           veloMin;
    public      float           velo;
    private     Vector3         posicaoInicial;
    public      GameObject      nuvemPrefab;

    // Start is called before the first frame update
    void Start(){
        nuvemRB = GetComponent<Rigidbody2D>();
        nuvemRB.gravityScale = 0;
        velo = Random.Range(veloMin, veloMax);
        nuvemRB.velocity =  new Vector2(-velo, 0);
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update(){ 
        if(transform.position.x < -41){
            this.transform.position = posicaoInicial;
            //Destroy(this.gameObject);
        }
    }


}

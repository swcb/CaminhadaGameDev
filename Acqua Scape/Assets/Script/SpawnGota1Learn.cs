using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SpawnGota1Learn : MonoBehaviour
{
    public  float               variacaoEsqX;
    public  float               variacaoDirX;
    public  float               positicaoY;
    private float               currentSpawn;
    public  int                 maxPossibilidades;
    public  GameObject          prefab;
    public  List<GameObject>    blocos;

    // Start is called before the first frame update
    void Start(){

        for(int i = 0; i < maxPossibilidades; i++){
            GameObject temporario = Instantiate(prefab) as GameObject;
            blocos.Add(temporario);
            temporario.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update(){
        
    }

    private void Spawn(){
        float random = Random.Range(variacaoEsqX, variacaoDirX);
        GameObject temporario = null;
        for(int i=0; i<maxPossibilidades; i++){
            if(blocos[i].activeSelf == false){
                temporario = blocos[i];
                break;
            }
        }

        if(temporario != null){
            temporario.transform.position = new Vector3(random, positicaoY, 0);
            temporario.SetActive(true);
        }
    }
}

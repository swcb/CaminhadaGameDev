using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGota1 : MonoBehaviour
{

    public  float               MinX;
    public  float               MaxX;
    public  float               positicaoY;
    private float               currentSpawn;
    public  GameObject          gotaPrefab;
    public  List<GameObject>    gotas;
    public  int                 gotaAtiva;
    
    // Start is called before the first frame update
    void Start()
    {
        positicaoY = transform.position.y;
        for(float x = MinX; x <= MaxX; x+=1){
            GameObject temporario = Instantiate(gotaPrefab) as GameObject;
            temporario.transform.position =  new Vector3(x, positicaoY, 0);
            gotas.Add(temporario);
            temporario.SetActive(false);
        }
        this.Spawn();
    }

    // Update is called once per frame
    void Update(){
        print(gotas[gotaAtiva].activeSelf);
        if (gotas[gotaAtiva].activeSelf == false){
            print("spawnando");
            this.Spawn();
        }
    }

    private void Spawn(){
        int random = Random.Range(0, (int)(MinX-MaxX));
        gotas[random].SetActive(true);
        gotaAtiva = random;
    }
}

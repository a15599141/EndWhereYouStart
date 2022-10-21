using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetromino : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    private int time = 5;
    private int maxNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        NewTetromino();
        Invoke("NewTetromino",time);
        Invoke("NewTetromino",time+5);
        Invoke("NewTetromino",time+10);
    }
    
    public void NewTetromino()
    {
        if(maxNum < 4){
            Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], new Vector3(Random.Range(-10, -15), 5f, 0), Quaternion.identity);
            maxNum++;
        }
    }
}

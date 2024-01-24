using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstacal;
    Player player;
    public bool stopSpawing = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnObstacal());
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }

    void Update(){
        if(player._gameOver == true){
            stopSpawing = true;
            Debug.Log("stop");
        }
    }
    IEnumerator spawnObstacal(){
        while(!stopSpawing){
            Instantiate(obstacal, new Vector3(21f, 0f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(1.2f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    // [SerializeField] GameObject playerPrefab;
    Player player;

    void Start(){
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player._gameOver){
            transform.Translate(Vector3.left * Time.deltaTime * _speed); 
        }  

        if(transform.position.x < -6 && gameObject.tag == "Obstacal"){
            Destroy(gameObject);
        } 
    }
}

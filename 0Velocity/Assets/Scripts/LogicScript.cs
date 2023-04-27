using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y <=-10)
        {
            player.transform.position = new Vector3(-17, -4, 0);
        }
    }
}

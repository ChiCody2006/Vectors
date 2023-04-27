using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] popUps;
    [SerializeField] GameObject player;
    private int popUpIndex = 0;
    bool pressed = false;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if(i==popUpIndex)
            {
                popUps[i].SetActive(true);
            } else
            {
                popUps[i].SetActive(false);
            }
        }

        if(popUpIndex==0)
        {
            if (Input.GetButton("Horizontal"))
            {
                popUpIndex++;
            }
            
        } else if(popUpIndex==1)
        {
            if(Input.GetButtonDown("Jump"))
            {
                popUpIndex++;
            }
        } else if(popUpIndex==2)
        {

            if (player.transform.position.y <= -6&&!pressed)
            {
                Time.timeScale = 0;
                if (Input.GetMouseButtonUp(0))
                {
                    Time.timeScale = 1;
                    pressed = true;
                }
            }
            
        }
    }

    
    
}

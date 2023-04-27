using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVector : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject arrow;
    private Vector3 rotation;
    private Vector3 mousePos;
    private float velX;
    private float velY;
    private float rotZ;
    private bool shouldMove;
    private float Timer;
    private float AdjustedY = 0;
    private float AdjustedX = 0;
    private bool clicked;

    private void FixedUpdate()
    {
        
        if (shouldMove)
        {
            Vector2 force = new Vector2(AdjustedX, AdjustedY);
            force.Normalize();
            force *= new Vector2(velX, velY);
            rb.velocity = Vector2.zero;
            rb.AddForce(force * Timer*80);
        }
        
        

    }
    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePosition.x, mousePosition.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider!=null)
        {
            if (hit.collider.gameObject.Equals(gameObject) && Input.GetButtonDown("Fire1"))
            {
                clicked = true;
            }
            
        }
        if (Input.GetButton("Fire1") && clicked)
            {
                velX = rb.velocity.x;
                velY = rb.velocity.y;
                Time.timeScale = 0;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rotation = mousePos - transform.position;
                rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0, 0, rotZ);

                arrow.SetActive(true);
                AdjustedY = (rotation.y > 0 && rb.velocity.y > 0) || (rotation.y < 0 && rb.velocity.y < 0) ? rotation.y : rotation.y * -1;
                AdjustedX = (rotation.x > 0 && rb.velocity.x > 0) || (rotation.x < 0 && rb.velocity.x < 0) ? rotation.x : rotation.x * -1;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                arrow.SetActive(false);
                Time.timeScale = 1;
                shouldMove = true;
                Timer = .5f;
                clicked = false;
                StartCoroutine(Change());
            }
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(.5f);
        Timer = 0;
        Debug.Log(Timer);
        shouldMove = false;
        Debug.Log("false");
    }
}

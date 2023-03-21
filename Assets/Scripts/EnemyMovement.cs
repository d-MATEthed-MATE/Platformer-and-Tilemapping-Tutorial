using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public bool MoveRight;


    // Update is called once per frame
    void Update()
    {
        if(MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed , 0,0);
            transform.localScale= new Vector2 (0.371525f, 0.315641f);
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * speed , 0,0);
            transform.localScale= new Vector2 (-0.371525f, 0.315641f);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("turn"))
        {
            if(MoveRight)
            {
                MoveRight= false;
            }
            else
            {
                MoveRight= true;
            }
        }
    }
}

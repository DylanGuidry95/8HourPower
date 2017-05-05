using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Vector3 TravelPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CharacterStates>())
        {

        }
    }
}

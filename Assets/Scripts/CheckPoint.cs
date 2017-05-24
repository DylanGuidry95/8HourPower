using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite CheckpointHit;
    public GameObject Flag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<CharacterStates>())
        {
            Events.CheckPointReachd.Invoke(this);
            Destroy(this.GetComponent<Collider2D>());
            Flag.GetComponent<SpriteRenderer>().sprite = CheckpointHit;
        }
    }
}

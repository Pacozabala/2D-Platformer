using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnewayPlatforms : MonoBehaviour
{
    public GameObject parent, player;
    public Collider2D parentColl;
    public PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        parentColl = parent.GetComponent<Collider2D>();
        pc = player.GetComponent<PlayerController>();
        Physics2D.IgnoreCollision(parentColl, pc.bodyCollider, true);
        Physics2D.IgnoreCollision(parentColl, pc.headCollider, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Body" || other.tag == "Head") {
            Physics2D.IgnoreCollision(parentColl, pc.footCollider, true);
        }
        else if (other.tag == "Feet" && other.bounds.min.y > parentColl.bounds.max.y) {
            Physics2D.IgnoreCollision(parentColl, other, false);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Feet") {
            Physics2D.IgnoreCollision(parentColl, other, false);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Feet" && other.bounds.min.y > parentColl.bounds.max.y) {
            Physics2D.IgnoreCollision(parentColl, other, false);
        }
    }
}

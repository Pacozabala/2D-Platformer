using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnewayPlatforms : MonoBehaviour
{
    public GameObject parent;
    public Collider2D parentColl;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        parentColl = parent.GetComponent<Collider2D>();
        offset = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherParent;
        Collider2D[] otherColl;
        otherParent = other.transform.parent.gameObject;
        otherColl = otherParent.GetComponentsInChildren<Collider2D>();
        if (other.tag == "Head" || other.tag == "Body") {
            foreach (Collider2D item in otherColl)
            {
                Physics2D.IgnoreCollision(parentColl, item, true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Feet") {
            Physics2D.IgnoreCollision(parentColl, other, false);
        }
    }
}

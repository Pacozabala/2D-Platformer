using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float xOffset, yOffset, speed = 10.0f;
    public Vector2 target;
    public Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        target = new Vector2(position.x + xOffset, position.y + yOffset);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        position = gameObject.transform.position;
        if (position == target) {
            xOffset *= -1;
            yOffset *= -1;
            target = new Vector2(position.x + xOffset, position.y + yOffset);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.transform.SetParent(null);
    }
}

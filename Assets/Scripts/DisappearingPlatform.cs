using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float decayTime, resetTime, elapsedTime;
    public bool decaying, reseting;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackTime();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Feet" && !decaying && !reseting) {
            decaying = true;
            elapsedTime = 0f;
        }
    }

    private void TrackTime() {
        if (decaying || reseting) {
            elapsedTime += Time.deltaTime;
        }
        if (decaying && elapsedTime > decayTime) {
            Decay();
        }
        else if (reseting && elapsedTime > resetTime) {
            Reset();
        }

    }

    private void Decay() {
        platform.SetActive(false);
        elapsedTime = 0f;
        decaying = false;
        reseting = true;
    }

    private void Reset() {
        platform.SetActive(true);
        elapsedTime = 0f;
        reseting = false;
    }
}

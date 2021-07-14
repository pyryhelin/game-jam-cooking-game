using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    public string choosenFood;
    public float speed = 0.5f;
    private Vector3 start, end; 
    
    private Vector3 positionAdjuster = new Vector3(0.1f, 0);

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D collider = GameObject.Find(choosenFood).GetComponent<BoxCollider2D>();
        start = new Vector3(collider.bounds.min.x-1, gameObject.transform.position.y, 0);
        end = new Vector3(collider.bounds.max.x+1, gameObject.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp (start, end, Mathf.PingPong(Time.time*speed, 1.0f));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingpPong : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 start, end; 
    
    public Vector2 distanceToMove;

    public Vector3 position; 
    // Start is called before the first frame update
    void Start()
    {
        start = new Vector3(position.x - distanceToMove.x / 2, position.y - distanceToMove.y, position.z);
        end = new Vector3(position.x + distanceToMove.x / 2, position.y + distanceToMove.y, position.z);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Vector3.Lerp (start, end, Mathf.PingPong(Time.time*speed, 1.0f));
    }
}

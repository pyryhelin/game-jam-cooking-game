using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCutColliders : MonoBehaviour
{
    public GameObject cutLine;
    public string choosenFood;
    public int cutPieces;

    private BoxCollider2D boxColl;
    private Vector3 startPosition, nextPosition;
    private float interval;

    // Start is called before the first frame update
    void Start()
    {
        boxColl = GameObject.Find(choosenFood).GetComponent<BoxCollider2D>();
        startPosition = new Vector3(boxColl.bounds.min.x, boxColl.bounds.center.y, 0);
        interval = boxColl.bounds.size.x / cutPieces;

        Instantiate(cutLine, startPosition, Quaternion.identity);
        Instantiate(cutLine, new Vector3(boxColl.bounds.max.x, boxColl.bounds.center.y, 0), Quaternion.identity);

        for(int i=1; i < cutPieces; i++)
        {
            nextPosition = startPosition + new Vector3(interval*i, 0, 0);
            Instantiate(cutLine, nextPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

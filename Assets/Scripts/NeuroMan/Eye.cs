using UnityEngine;

public class Eye : MonoBehaviour {

    void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, Input.mousePosition, 1.0f);
	}
    
}

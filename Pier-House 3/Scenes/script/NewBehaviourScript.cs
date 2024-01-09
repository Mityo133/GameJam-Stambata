using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float horizontal;
    public float vertical;
    public float speed = 5.0f;
    void LateUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward* horizontal*speed*Time.deltaTime);
        transform.Translate(Vector3.left * vertical * speed * Time.deltaTime);
    }
}

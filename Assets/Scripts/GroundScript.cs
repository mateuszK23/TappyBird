using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1f, 0f, 0f) * 5f * Time.deltaTime;
        if (transform.position.x < -18.8f) transform.position = new Vector3(18.5f, -4.36f, 0.54f);
    }


}

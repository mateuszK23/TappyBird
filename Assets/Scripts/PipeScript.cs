using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private const float PLAYER_POSITION_X = 0f;
    public bool bottomPipe = false;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        movePipe();
    }

    private void movePipe()
    {
        bool isToRightOfPlayer = transform.position.x > PLAYER_POSITION_X;
        transform.position += new Vector3(-1f, 0f, 0f) * 5f * Time.deltaTime;
        if (isToRightOfPlayer && transform.position.x < PLAYER_POSITION_X && bottomPipe)
        {
            StateController.score++;
        } 
    }
 
}

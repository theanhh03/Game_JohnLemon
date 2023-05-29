using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnd;
    bool isLose;
        
    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            isLose = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isLose = false;
        }
    }
    void Update()
    {
        if (isLose)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    gameEnd.CaughtPlayer();
                }
            }
        }
    }
}

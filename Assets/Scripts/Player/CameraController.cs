using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 relativePosition;
    public bool fixedY = false;

    private float initialY;

    private GameObject player;
    void Awake()
    {
        player = GameObjectRegistry.Instance.player;
        // get position relative to player
        relativePosition = transform.position - player.transform.position;
        initialY = transform.position.y;
    }
    void FixedUpdate()
    {
        // set position relative to player
        if(!fixedY)
            transform.position = player.transform.position + relativePosition;
        else
            transform.position = new Vector3(player.transform.position.x + relativePosition.x, initialY, player.transform.position.z + relativePosition.z);
    }
}

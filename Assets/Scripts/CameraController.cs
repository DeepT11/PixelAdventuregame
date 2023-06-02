using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    [SerializeField] private Transform player;
    //Drag and drop the player in the camera controller field

    //Need a reference to the transform component of the player
    private void Update()
    {   
        //keep our z value for the z axis
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}

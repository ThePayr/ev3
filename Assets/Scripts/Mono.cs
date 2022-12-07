using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Mono : MonoBehaviour
{
    

    public Vector2 InputVector { get; private set; }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        var h = CrossPlatformInputManager.GetAxis("Horizontal");
        var v = CrossPlatformInputManager.GetAxis("Vertical");
        InputVector = new Vector2(h, v);
    }

}

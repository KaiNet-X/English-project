using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float SpeedMultiplier = 1f;
    public bool Enabled = false;

    void Update()
    {
        if (Enabled)
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * SpeedMultiplier * Time.deltaTime, 0));
    }
}

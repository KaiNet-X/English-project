using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float SpeedMultiplier = 1f;
    private float xScale;

    private void Start()
    {
        xScale = gameObject.transform.localScale.x;
    }
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * SpeedMultiplier * Time.deltaTime, 0));
        transform.localScale = new Vector3(getFlip() * xScale, transform.localScale.y, 1);
    }

    private int getFlip()
    {
        return Input.GetAxis("Horizontal") >= 0 ? 1 : -1;
    }
}

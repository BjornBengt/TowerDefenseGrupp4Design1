using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForwardScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Time.timeScale = 40f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}

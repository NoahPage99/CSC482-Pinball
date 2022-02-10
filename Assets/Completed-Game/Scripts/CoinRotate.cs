using UnityEngine;
using System.Collections;

public class CoinRotate : MonoBehaviour {

    private void Start()
    {

    }

    // Before rendering each frame..
    void Update () 
    {
         //continuously rotates cuvbe
        transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
    }
}   
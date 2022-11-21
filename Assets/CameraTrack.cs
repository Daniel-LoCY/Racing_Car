using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField] GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cam.GetComponent<Transform>().position = new Vector3(this.GetComponent<Transform>().position.x-10f, this.GetComponent<Transform>().position.y+5f, this.GetComponent<Transform>().position.z);
    }
}

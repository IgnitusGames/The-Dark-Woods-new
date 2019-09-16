using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.x, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);

    }
}

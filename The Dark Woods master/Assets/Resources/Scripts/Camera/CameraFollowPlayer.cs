using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Variables
    public GameObject Player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        //Offset = transform.position - Player.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp(Player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(Player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}

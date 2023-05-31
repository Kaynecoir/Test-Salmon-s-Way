using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPlayerController : MonoBehaviour
{
    public float maxSpeed;

    [SerializeField]
    private GameObject Arrow;
    [SerializeField]
    private Vector3 mousePos;
    [SerializeField]
    private Quaternion angle;
    private CharacterController charControll;
    void Start()
    {
        charControll = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal, 0.0f, vertical).normalized * maxSpeed;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        mousePos.y = 0.0f;

        Arrow.transform.right = mousePos;

        this.transform.position += velocity * Time.deltaTime;


    }
}

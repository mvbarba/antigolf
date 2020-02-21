using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{

    public enum HoleMoveType
    {
        Static,
        Linear,
        Homing
    }

    public HoleMoveType moveType;

    Transform target; 
    private Rigidbody2D rb;
    public float speed = 5f;
    public float rotateSpeed = 200f;

    public bool active;

    private static bool isMoving;

    private SpriteRenderer sprite;
    private Quaternion startingRotation;

    public static void enableMovement(bool set)
    {
        isMoving = set;
    }

    private void Awake()
    {
        active = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = PlayerController.Instance().transform;
        sprite = GetComponentInChildren<SpriteRenderer>();
        startingRotation = sprite.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (GameplayManager.Instance().active)
        {
            if (isMoving)
            {
                if (moveType == HoleMoveType.Homing)
                {
                    Vector2 direction = (Vector2)target.position - rb.position;
                    direction.Normalize();

                    float rotateAmount = Vector3.Cross(direction, transform.up).z;

                    rb.angularVelocity = -rotateAmount * rotateSpeed;

                    rb.velocity = transform.up * speed;
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        sprite.transform.rotation = startingRotation;
    }
}

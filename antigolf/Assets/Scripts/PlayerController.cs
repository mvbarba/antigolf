using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public float speed = -100;

    LineRenderer line;

    Vector2 endPos, startPos;

    bool falling = false;
    bool aiming = false;
    bool ready = true;

    public bool active;

    public static PlayerController Instance()
    {
        return instance;
    }

    private void Awake()
    {
        active = true;
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponentInChildren<LineRenderer>();
        HoleController.enableMovement(true);
        GameplayManager game = GameplayManager.Instance();
    }

    void ShootBall()
    {
        GameplayManager game = GameplayManager.Instance();
        if (!game.active)
            game.StartMatch();
        game.active = true;
        game.strokes--;
        aiming = false;
        Debug.Log("SHOOTING BALL TO " + endPos.ToString());
        Vector2 direction = startPos - endPos;
        this.GetComponent<Rigidbody2D>().AddForce(direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.TAG_HOLE)
        {
            StartFall(collision);
        }
    }

    Vector2 fallingPosition;
    Vector2 startingPosition;
    Vector2 startingScale; 

    private void StartFall(Collider2D collision)
    {
        Vector2 position = collision.transform.position;
        Destroy(this.GetComponent<Rigidbody2D>());
        Destroy(this.GetComponent<CircleCollider2D>());
        falling = true;
        fallingPosition = position;
        startingPosition = transform.position;
        startingScale = transform.localScale;
        HoleController.enableMovement(false);
    }

    private void HandleFall()
    {
        {
            transform.position = Vector2.Lerp(transform.position, fallingPosition, Time.deltaTime*4);
            transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime*4);
        }
        if (transform.localScale.x < 0.01f)
        {
            GameplayManager.Instance().LoseRound(fallingPosition);
            Debug.Log("Done falling");
            active = false;
        }
    }

    public void Disable()
    {
        line.enabled = false;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (falling)
            {
                TimerController.Instance().timing = false;
                if (!GameplayManager.Instance().lost)
                    HandleFall();
                return;
            }

            if (Input.GetMouseButtonDown(0) && !aiming)
            {
                aiming = true;
            }

            if (Input.GetMouseButtonUp(0) && aiming)
            {
                if (GameplayManager.Instance().strokes != 0)
                    ShootBall();
            }


            if (aiming)
            {
                line.enabled = true;
                line.SetPosition(0, transform.position);
                Vector2 shootPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                shootPos = (Vector2)transform.position + ((Vector2)transform.position - shootPos);
                endPos = shootPos;
                startPos = transform.position;

                //CHECK IF WE ARE OVER MAX DISTANCE
                if (Vector2.Distance(transform.position, shootPos) > 5)
                {
                    Vector2 dir = endPos - (Vector2)transform.position;
                    endPos = (Vector2)transform.position + (dir.normalized * 5);
                }

                float distance = Vector3.Distance(transform.position, endPos);
                line.material.mainTextureScale = new Vector2(distance * 0.2f, 1);

                line.SetPosition(1, endPos);
            }
            else
            {
                line.enabled = false;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainPlayer : MonoBehaviour
{
    public enum Direction
    {
        Up,Right,Left
    }//局部枚举变量
    private Direction Dir;
    private BoxCollider2D coll;
    private SpriteRenderer Renderer;
    private Animator anim;
    private Rigidbody2D rb;
    private float MoveDistance;
    private bool ButtonHold;
    private bool isJump;
    private bool CanJump;
    private bool inWater;
    private bool isdead;
    private Vector2 destnation;
    private Vector2 touchPosition;
    private RaycastHit2D[] result = new RaycastHit2D[2];
    [Header("得分")]
    public int stepCount;
    private int AllCount;
    [Header("跳跃")]
    public float JumpDistance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Renderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (CanJump)
        {
            TriggerJump();
        }
    }
    private void FixedUpdate()
    {
        rb.position = Vector2.Lerp(transform.position,destnation,0.134f);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && !isJump)
        {
            MoveDistance = JumpDistance;
            CanJump = true;
        }
        if(Dir == Direction.Up && context.performed && !isJump && !isdead)
        {
            AllCount += stepCount;
        }
    }
    public void LongJump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJump)
        {
            MoveDistance = JumpDistance * 2;
            ButtonHold = true;
        }
        if (context.canceled && ButtonHold)
        {
            destnation = new Vector2(transform.position.x, transform.position.y + MoveDistance);
            ButtonHold = false;
            CanJump = true;
            if(Dir == Direction.Up && !isdead)
            {
                AllCount += stepCount * 2;
            }
        }
    }
    public void TouchPosition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            var offect = ((Vector3)touchPosition - transform.position).normalized;
            if (math.abs(offect.x) <= 0.7f)
            {
                Dir = Direction.Up;
            }
            else if (offect.x < 0)
            {
                Dir = Direction.Left;
            }
            else if (offect.x > 0)
            {
                Dir = Direction.Right;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Border" || other.tag == "car")
        {
            isdead = true;
        }
        if(!isJump && other.tag == "Enemy")
        {
            isdead = true;
        }
        if(!isJump && other.tag == "water")
        {
            inWater = true;
            Physics2D.RaycastNonAlloc(transform.position + Vector3.up * 0.1f, Vector2.zero, result);
            foreach(var hit in result)
            {
                if(hit.collider.tag == null)
                {
                    continue;
                }
                if(hit.collider.tag == "wood")
                {
                    transform.parent = hit.collider.transform;
                    inWater = false;
                }
            }
            if(inWater && !isJump)
            {
                isdead = true;
            }
        }
        if (isdead)
        {
            StringEventSO.CallGameOverEvent();
            coll.enabled = false;
        }
    }
    private void TriggerJump()
    {
        CanJump = false;
        switch (Dir)
        {
            case Direction.Up:
                anim.SetBool("LeftHide", false);
                transform.localScale = Vector3.one;
                destnation = new Vector2(transform.position.x, transform.position.y + MoveDistance);
                break;
            case Direction.Left:
                anim.SetBool("LeftHide", true);
                transform.localScale = Vector3.one;
                destnation = new Vector2(transform.position.x - MoveDistance, transform.position.y);
                break;
            case Direction.Right:
                anim.SetBool("LeftHide", true);
                transform.localScale = new Vector3(-1, 1, 1);
                destnation = new Vector2(transform.position.x + MoveDistance, transform.position.y);
                break;
        };
        anim.SetTrigger("Jump");
    }
    public void JumpAnimEvent()
    {
        isJump = true;
        transform.parent = null;
        Renderer.sortingLayerName = "Front";
    }
    public void EndJumpAnimEvent()
    {
        isJump = false;
        Renderer.sortingLayerName = "Center";
        if(Dir == Direction.Up && !isdead)
        {
            StringEventSO.CallGetPointEvent(AllCount);
        }
    }
}

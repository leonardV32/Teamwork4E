using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Platformer_test : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxspeed;
    [SerializeField] private float jumpForce;

    private PlayerController controls;

    private SpriteRenderer spriterenderer;

    private Animator animator;

    private Rigidbody2D rb2D;

    private float direction;

    private void OnEnable()
    {
        controls = new PlayerController();
        controls.Enable();
        controls.Main.Jump.performed += JumpOnperformed;
        controls.Main.Move.performed += MoveOnperformed;
        controls.Main.Move.canceled += MoveOncanceled;
    }


    private void JumpOnperformed(InputAction.CallbackContext obj)
    {

    }

    private void MoveOnperformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<float>();
        if (direction > 0)
        {
            spriterenderer.flipX = false;
        }
        else
        {
            spriterenderer.flipX = true;
        }
    }

    private void MoveOncanceled(InputAction.CallbackContext obj)
    {
        direction = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var horizontalSpeed = Mathf.Abs(rb2D.velocity.x);
        if (horizontalSpeed < maxspeed)
        {
            rb2D.AddForce(new Vector2(speed * direction, 0));
        }

    }
}

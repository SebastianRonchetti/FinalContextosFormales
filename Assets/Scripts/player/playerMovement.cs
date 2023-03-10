using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    bool disabled = false;

    public CharacterController playerController;
    static playerPowerUpInteraction playerPowerUpInteractionSc;
    public float gear1 = 8f, gear2 = 16f,
        jumpPower1 = 4f, jumpPower2 = 10f, 
        gravityStrenght = -16.8f, groundDistance = 0.5f;
    public bool jumpBoost = false, speedBoost = false;
    [SerializeField] bool isGrounded;
    Vector3 velocity;
    public Transform groundCheck;
    public LayerMask groundMask;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerPowerUpInteractionSc = playerPowerUpInteraction.getSingleton();
        playerPowerUpInteractionSc.onPowerUpSwitch += activateBuffStatus;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            float moveX = Input.GetAxis("Vertical");
            float moveZ = Input.GetAxis("Horizontal");

            Vector3 move = transform.right * moveZ + transform.forward * moveX;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0.2f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                if (jumpBoost)
                {
                    velocity.y = Mathf.Sqrt(jumpPower2 * -2 * gravityStrenght);
                }
                else
                {
                    velocity.y = Mathf.Sqrt(jumpPower1 * -2 * gravityStrenght);
                }
            }

            if (speedBoost)
            {
                playerController.Move(move * gear2 * Time.deltaTime);
            }
            else
            {
                playerController.Move(move * gear1 * Time.deltaTime);
            }

            velocity.y += gravityStrenght * Time.deltaTime;

            playerController.Move(velocity * Time.deltaTime);
        }
    }

    void activateBuffStatus(object sender, playerPowerUpInteraction.onPowerUpSwitch_eventArgs e)
    {
        StartCoroutine(changeBoostStatus(e.powerId, e.buffDuration));
    }

    IEnumerator changeBoostStatus(int boost, float buffDuration)
    {
        if (boost == 2) 
        {
            jumpBoost = true;
            speedBoost = false;
        }
        else if (boost == 3) 
        {
            speedBoost = true;
            jumpBoost = false;
        }

        if (boost == 2)
        {
            yield return new WaitForSeconds(buffDuration); 
            jumpBoost = false;
        }
        else if (boost == 3)
        {
            speedBoost = false;
        }
    }

    public void changeAble()
    {
        disabled = !disabled;
    }
}

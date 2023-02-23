using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animator;
    private GameManager gameManager;
    private PlayerController playerController;
    private Yeeter yeeter;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        bool wKey = verticalInput > 0;
        bool aKey = horizontalInput < 0;
        bool sKey = verticalInput < 0;
        bool dKey = horizontalInput > 0;



        //Animations
        float angle = transform.rotation.eulerAngles.y;

        // Direction Integer Key \\

        //-1: Idle
        // 0: Front
        // 1: Front-Right
        // 2: Right
        // 3: Back-Right
        // 4: Back
        // 5: Back-Left
        // 6: Left
        // 7: Front-Left


        if (gameManager.gameActive)
        {
            //Facing Forwards
            if ((angle >= 67.5f && angle <= 112.5f))
            {
                if (wKey)
                {
                    if (aKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 7);
                    }
                    else if (dKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (!aKey || !dKey) //Walk Forwards
                    {
                        animator.SetInteger("direction", 0);
                    }
                }
                else if (sKey)
                {
                    if (aKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 5);
                    }
                    else if (dKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 3);
                    }
                    else if (!aKey || !dKey) //Walk Backwards
                    {
                        animator.SetInteger("direction", 4);
                    }
                }
                else if (aKey)
                {
                    if (wKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 7);
                    }
                    else if (sKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 5);
                    }
                    else if (!wKey || !sKey) //Walk Left
                    {
                        animator.SetInteger("direction", 6);
                    }
                }
                else if (dKey)
                {
                    if (wKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (sKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 3);
                    }
                    else if (!wKey || !sKey) //Walk Right
                    {
                        animator.SetInteger("direction", 2);
                    }
                }
                else
                {
                    animator.SetInteger("direction", -1);
                }
            }


            // Facing Forwards Right
            else if ((angle >= 112.5f && angle < 157.5f))
            {
                if (wKey)
                {
                    if (aKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 6);
                    }
                    else if (dKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 0);
                    }
                    else if (!aKey || !dKey) //Walk Forwards
                    {
                        animator.SetInteger("direction", 7);
                    }
                }
                else if (sKey)
                {
                    if (aKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 4);
                    }
                    else if (dKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 2);
                    }
                    else if (!aKey || !dKey) //Walk Backwards
                    {
                        animator.SetInteger("direction", 3);
                    }
                }
                else if (aKey)
                {
                    if (wKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 6);
                    }
                    else if (sKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 4);
                    }
                    else if (!wKey || !sKey) //Walk Left
                    {
                        animator.SetInteger("direction", 5);
                    }
                }
                else if (dKey)
                {
                    if (wKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 0);
                    }
                    else if (sKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 2);
                    }
                    else if (!wKey || !sKey) //Walk Right
                    {
                        animator.SetInteger("direction", 1);
                    }
                }
                else
                {
                    animator.SetInteger("direction", -1);
                }
            }
            else if ((angle > 157.5f && angle < 202.5f)) // Facing Right
            {
                if (wKey)
                {
                    if (aKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 5);
                    }
                    else if (dKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 7);
                    }
                    else if (!aKey || !dKey) //Walk Forwards
                    {
                        animator.SetInteger("direction", 6);
                    }
                }
                else if (sKey)
                {
                    if (aKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 3);
                    }
                    else if (dKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (!aKey || !dKey) //Walk Backwards
                    {
                        animator.SetInteger("direction", 2);
                    }
                }
                else if (aKey)
                {
                    if (wKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 5);
                    }
                    else if (sKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 3);
                    }
                    else if (!wKey || !sKey) //Walk Left
                    {
                        animator.SetInteger("direction", 4);
                    }
                }
                else if (dKey)
                {
                    if (wKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 7);
                    }
                    else if (sKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (!wKey || !sKey) //Walk Right
                    {
                        animator.SetInteger("direction", 0);
                    }
                }
                else
                {
                    animator.SetInteger("direction", -1);
                }
            }
            else if ((angle > 202.5f && angle < 247.5f)) // Facing Backwards Right
            {
                if (wKey)
                {
                    if (aKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 4);
                    }
                    else if (dKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 6);
                    }
                    else if (!aKey || !dKey) //Walk Forwards
                    {
                        animator.SetInteger("direction", 5);
                    }
                }
                else if (sKey)
                {
                    if (aKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 2);
                    }
                    else if (dKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 0);
                    }
                    else if (!aKey || !dKey) //Walk Backwards
                    {
                        animator.SetInteger("direction", 1);
                    }
                }
                else if (aKey)
                {
                    if (wKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 4);
                    }
                    else if (sKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 2);
                    }
                    else if (!wKey || !sKey) //Walk Left
                    {
                        animator.SetInteger("direction", 3);
                    }
                }
                else if (dKey)
                {
                    if (wKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 6);
                    }
                    else if (sKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 0);
                    }
                    else if (!wKey || !sKey) //Walk Right
                    {
                        animator.SetInteger("direction", 7);
                    }
                }
                else
                {
                    animator.SetInteger("direction", -1);
                }
            }
            else if ((angle > 247.5f && angle < 292.5f)) // Facing Backwards
            {
                if (wKey)
                {
                    if (aKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 3);
                    }
                    else if (dKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 5);
                    }
                    else if (!aKey || !dKey) //Walk Forwards
                    {
                        animator.SetInteger("direction", 4);
                    }
                }
                else if (sKey)
                {
                    if (aKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (dKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 7);
                    }
                    else if (!aKey || !dKey) //Walk Backwards
                    {
                        animator.SetInteger("direction", 0);
                    }
                }
                else if (aKey)
                {
                    if (wKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 3);
                    }
                    else if (sKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (!wKey || !sKey) //Walk Left
                    {
                        animator.SetInteger("direction", 2);
                    }
                }
                else if (dKey)
                {
                    if (wKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 5);
                    }
                    else if (sKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 7);
                    }
                    else if (!wKey || !sKey) //Walk Right
                    {
                        animator.SetInteger("direction", 6);
                    }
                }
                else
                {
                    animator.SetInteger("direction", -1);
                }
            }
            else if ((angle > 292.5f && angle < 337.5f)) // Facing Backwards Left
            {
                if (wKey)
                {
                    if (aKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 2);
                    }
                    else if (dKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 4);
                    }
                    else if (!aKey || !dKey) //Walk Forwards
                    {
                        animator.SetInteger("direction", 3);
                    }
                }
                else if (sKey)
                {
                    if (aKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 0);
                    }
                    else if (dKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 6);
                    }
                    else if (!aKey || !dKey) //Walk Backwards
                    {
                        animator.SetInteger("direction", 7);
                    }
                }
                else if (aKey)
                {
                    if (wKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 2);
                    }
                    else if (sKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 0);
                    }
                    else if (!wKey || !sKey) //Walk Left
                    {
                        animator.SetInteger("direction", 1);
                    }
                }
                else if (dKey)
                {
                    if (wKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 4);
                    }
                    else if (sKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 6);
                    }
                    else if (!wKey || !sKey) //Walk Right
                    {
                        animator.SetInteger("direction", 5);
                    }
                }
                else
                {
                    animator.SetInteger("direction", -1);
                }
            }
            else if ((angle > 337.5f && angle < 22.5f)) // Facing Left
            {
                if (wKey)
                {
                    if (aKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (dKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 3);
                    }
                    else if (!aKey || !dKey) //Walk Forwards
                    {
                        animator.SetInteger("direction", 2);
                    }
                }
                else if (sKey)
                {
                    if (aKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 7);
                    }
                    else if (dKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 5);
                    }
                    else if (!aKey || !dKey) //Walk Backwards
                    {
                        animator.SetInteger("direction", 6);
                    }
                }
                else if (aKey)
                {
                    if (wKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (sKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 7);
                    }
                    else if (!wKey || !sKey) //Walk Left
                    {
                        animator.SetInteger("direction", 0);
                    }
                }
                else if (dKey)
                {
                    if (wKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 3);
                    }
                    else if (sKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 5);
                    }
                    else if (!wKey || !sKey) //Walk Right
                    {
                        animator.SetInteger("direction", 4);
                    }
                }
                else
                {
                    animator.SetInteger("direction", -1);
                }
            }
            else if ((angle > 22.5f && angle < 67.5f)) //Facing Forwards Left
            {
                if (wKey)
                {
                    if (aKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 0);
                    }
                    else if (dKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 2);
                    }
                    else if (!aKey || !dKey) //Walk Forwards
                    {
                        animator.SetInteger("direction", 1);
                    }
                }
                else if (sKey)
                {
                    if (aKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 6);
                    }
                    else if (dKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 4);
                    }
                    else if (!aKey || !dKey) //Walk Backwards
                    {
                        animator.SetInteger("direction", 5);
                    }
                }
                else if (aKey)
                {
                    if (wKey) //Walk Forwards Left
                    {
                        animator.SetInteger("direction", 1);
                    }
                    else if (sKey) //Walk Backwards Left
                    {
                        animator.SetInteger("direction", 6);
                    }
                    else if (!wKey || !sKey) //Walk Left
                    {
                        animator.SetInteger("direction", 7);
                    }
                }
                else if (dKey)
                {
                    if (wKey) //Walk Forwards Right
                    {
                        animator.SetInteger("direction", 2);
                    }
                    else if (sKey) //Walk Backwards Right
                    {
                        animator.SetInteger("direction", 4);
                    }
                    else if (!wKey || !sKey) //Walk Right
                    {
                        animator.SetInteger("direction", 3);
                    }
                }
                else
                {
                    animator.SetInteger("direction", -1);
                }
            }
        }
    }
    
}

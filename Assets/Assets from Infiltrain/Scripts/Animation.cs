using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animator;
    private GameManager gameManager;






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
        float playerRotationy = transform.eulerAngles.y;

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

        if ((playerRotationy > 67.5 || playerRotationy < 112.5)) //Facing Forwards
        {

            if(wKey)
            {
                if(aKey) //Walk Forwards Left
                {
                    animator.SetInteger("direction", 7);
                }
                else if (dKey) //Walk Forwards Right
                {
                    animator.SetInteger("direction", 1);
                }
                else if(!aKey || !dKey) //Walk Forwards
                {
                    animator.SetInteger("direction", 0);
                }
            }
            else if (sKey)
            {
                if(aKey) //Walk Backwards Left
                {
                    animator.SetInteger("direction", 5);
                }
                else if (dKey) //Walk Backwards Right
                {
                    animator.SetInteger("direction", 3);
                }
                else if(!aKey || !dKey) //Walk Backwards
                {
                    animator.SetInteger("direction", 4);
                }
            }
            else if (aKey)
            {
                if(wKey) //Walk Forwards Left
                {
                    animator.SetInteger("direction", 7);
                }
                else if (sKey) //Walk Backwards Left
                {
                    animator.SetInteger("direction", 5);
                }
                else if(!wKey || !sKey) //Walk Left
                {
                    animator.SetInteger("direction", 6);
                }
            }
            else if (dKey)
            {
                if(wKey) //Walk Forwards Right
                {
                    animator.SetInteger("direction", 1);
                }
                else if (sKey) //Walk Backwards Right
                {
                    animator.SetInteger("direction", 3);
                }
                else if(!wKey || !sKey) //Walk Right
                {
                    animator.SetInteger("direction", 2);
                }
            }
            else
            {
                animator.SetInteger("direction", -1);
            }
            
            
        }
        else if ((playerRotationy > 112.5 || playerRotationy < 157.5)) // Facing Forwards Right
        {
            
        }
        else if ((playerRotationy > 157.5 || playerRotationy < 202.5)) // Facing Right
        {
            
        }
        else if ((playerRotationy > 202.5 || playerRotationy < 247.5)) // Facing Backwards Right
        {
            
        }
        else if ((playerRotationy > 247.5 || playerRotationy < 292.5)) // Facing Backwards
        {
            
        }
        else if ((playerRotationy > 292.5 || playerRotationy < 337.5)) // Facing Backwards Left
        {
            
        }
        else if ((playerRotationy > 337.5 || playerRotationy < 22.5)) // Facing Left
        {
            
        }
        else if ((playerRotationy > 22.5 || playerRotationy < 67.5)) //Facing Forwards Left
        {
            
        }
    }

}

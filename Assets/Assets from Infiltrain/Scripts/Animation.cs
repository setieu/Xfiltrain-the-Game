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

        bool waKey = verticalInput > 0 && horizontalInput < 0;
        bool wdKey = verticalInput > 0 && horizontalInput > 0;
        bool saKey = verticalInput < 0 && horizontalInput < 0;
        bool sdKey = verticalInput < 0 && horizontalInput > 0;

        //Animations

        float playerRotationy = transform.eulerAngles.y;


        if ((playerRotationy > 67.5 || playerRotationy < 112.5) && gameManager.gameActive == true)
        {

            if(wKey)
            {
                if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
                {
                    animator.SetBool("fLeft", true);
                    animator.SetBool("walking", false);
                    animator.SetBool("fright", false);
                }
                else if (Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
                {
                    animator.SetBool("fRight", true);
                    animator.SetBool("walking", false);
                    animator.SetBool("fLeft", false);
                }
                else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                {
                    animator.SetBool("walking", true);
                    animator.SetBool("fLeft", false);
                    animator.SetBool("fright", false);
                }
            }
            else if (sKey)
            {
                if (saKey)
                {
                    animator.SetBool("walkBack", false);
                    animator.SetBool("walkleft", false);
                    animator.SetBool("bLeft", true);
                }
                else if (sdKey)
                {
                    animator.SetBool("walkBack", false);
                    animator.SetBool("walkright", false);
                    animator.SetBool("bRight", true);
                }
                else if (saKey == false || sdKey == false)
                {
                    animator.SetBool("walkBack", true);
                }
            }
            else if (aKey)
            {
                if (waKey)
                {
                    animator.SetBool("walkleft", false);
                    animator.SetBool("walking", false);
                    animator.SetBool("fLeft", true);
                }
                else if (saKey)
                {
                    animator.SetBool("walkleft", false);
                    animator.SetBool("walkBack", false);
                    animator.SetBool("fLeft", true);
                }
                else if (waKey == false || saKey == false)
                {
                    animator.SetBool("walkleft", true);
                }
            }
            else if (dKey)
            {
                if (wdKey)
                {
                    animator.SetBool("fRight", true);
                    animator.SetBool("walkright", false);
                    animator.SetBool("walking", false);
                }
                else if (sdKey)
                {
                    animator.SetBool("fRight", true);
                    animator.SetBool("walkright", false);
                    animator.SetBool("walkBack", false);
                }
                else if (wdKey == false || sdKey == false)
                {
                    animator.SetBool("walkright", true);
                }
            }
            else
            {
                animator.SetBool("walking", false);
                animator.SetBool("walkright", false);
                animator.SetBool("walkleft", false);
                animator.SetBool("walkBack", false);
                animator.SetBool("fLeft", false);
                animator.SetBool("fRight", false);
                animator.SetBool("bLeft", false);
                animator.SetBool("bRight", false);
            }
            
            
        }
        else if ((playerRotationy > 112.5 || playerRotationy < 157.5) && gameManager.gameActive == true)
        {
            
        }
        else if ((playerRotationy > 157.5 || playerRotationy < 202.5) && gameManager.gameActive == true)
        {
            
        }
        else if ((playerRotationy > 202.5 || playerRotationy < 247.5) && gameManager.gameActive == true)
        {
            
        }
        else if ((playerRotationy > 247.5 || playerRotationy < 292.5) && gameManager.gameActive == true)
        {
            
        }
        else if ((playerRotationy > 292.5 || playerRotationy < 337.5) && gameManager.gameActive == true)
        {
            
        }
        else if ((playerRotationy > 337.5 || playerRotationy < 22.5) && gameManager.gameActive == true)
        {
            
        }
        else if ((playerRotationy > 22.5 || playerRotationy < 67.5) && gameManager.gameActive == true)
        {
            
        }
    }

}

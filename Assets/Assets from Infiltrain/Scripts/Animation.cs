using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        bool waKey = Input.GetKeyDown(KeyCode.W)== true && Input.GetKeyDown(KeyCode.A)== true;
        bool wdKey = Input.GetKeyDown(KeyCode.W)== true && Input.GetKeyDown(KeyCode.D)== true;
        bool sdKey = Input.GetKeyDown(KeyCode.S)== true && Input.GetKeyDown(KeyCode.D)== true;
        bool saKey = Input.GetKeyDown(KeyCode.S)== true && Input.GetKeyDown(KeyCode.A)== true;



        //Animations

        float playerRotationy = transform.eulerAngles.y;


        if (playerRotationy > 67.5 || playerRotationy < 112.5)
        {

            if(waKey)
            {
                animator.SetBool("fLeft", true);
                animator.SetBool("walking", false);
            }
            else if (wdKey)
            {
                animator.SetBool("fRight", true);
                animator.SetBool("walking", false);
            }
            else if (saKey)
            {
                animator.SetBool("bLeft", true);
                animator.SetBool("walkBack", false);
            }
            else if (sdKey)
            {
                animator.SetBool("bRight", true);
                animator.SetBool("walkBack", false);
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    animator.SetBool("walking", true);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    animator.SetBool("walkleft", true);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    animator.SetBool("walkBack", true);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    animator.SetBool("walkright", true);
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
            
        }
        else if (playerRotationy > 112.5 || playerRotationy < 157.5)
        {
            if (verticalInput > 0)
            {
                animator.SetBool("fRight", true);
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
        else if (playerRotationy > 157.5 || playerRotationy < 202.5)
        {
            if (verticalInput > 0)
            {
                animator.SetBool("walkright", true);
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
        else if (playerRotationy > 202.5 || playerRotationy < 247.5)
        {
            if (verticalInput > 0)
            {
                animator.SetBool("bRight", true);
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
        else if (playerRotationy > 247.5 || playerRotationy < 292.5)
        {
            if (verticalInput > 0)
            {
                animator.SetBool("walkBack", true);
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
        else if (playerRotationy > 292.5 || playerRotationy < 337.5)
        {
            if (verticalInput > 0)
            {
                animator.SetBool("bLeft", true);
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
        else if (playerRotationy > 337.5 || playerRotationy < 22.5)
        {
            if (verticalInput > 0)
            {
                animator.SetBool("walkleft", true);
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
        else if (playerRotationy > 22.5 || playerRotationy < 67.5)
        {
            if (verticalInput > 0)
            {
                animator.SetBool("fLeft", true);
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
    }

}

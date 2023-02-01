using UnityEngine;

public class Animation : MonoBehaviour
{

    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetFloat("vertical", Input.GetAxis("Horizontal"));
    }

}

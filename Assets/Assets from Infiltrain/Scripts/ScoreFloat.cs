using UnityEngine;
using UnityEngine.UI;

public class ScoreFloat : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float lifeTime = 1f;
    private Text text;
    private RectTransform rectTransform;
    private float timer;
    public GameObject scoreSpawn;

    void Start()
    {
        text = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
        timer = 0f;
        CreateFloatingText();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
            return;
        }

        

        rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;
    }

    public static void CreateFloatingText()
    {
        Debug.Log("Run");
        GameObject floatingTextObj = new GameObject("Floating Text", typeof(RectTransform), typeof(CanvasRenderer), typeof(Text), typeof(ScoreFloat));
        //floatingTextObj.transform.SetParent(parent, false);
        floatingTextObj.transform.position = new Vector3(21,68,0);

        Text text = floatingTextObj.GetComponent<Text>();
        text.text = "Enemy Wiped +100";

        ScoreFloat floatingText = floatingTextObj.GetComponent<ScoreFloat>();
        Destroy(floatingTextObj, floatingText.lifeTime);
        Debug.Log("created and destroyed");
    }
}
using UnityEngine;
using UnityEngine.UI;

public class ScoreFloat : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float lifeTime = 1f;
    private Text text;
    private RectTransform rectTransform;
    private float timer;
    public int fontSize = 20;


    void Start()
    {
        Debug.Log("hihi");
        text = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
        timer = 0f;
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


    public static void CreateFloatingText(string text, Vector3 position)
    {
        GameObject floatingTextObj = new GameObject("Floating Text", typeof(RectTransform), typeof(CanvasRenderer), typeof(Text), typeof(ScoreFloat));
        floatingTextObj.transform.SetParent(GameObject.Find("Canvas").transform);
        floatingTextObj.transform.position = position;

        Text floatingText = floatingTextObj.GetComponent<Text>();
        floatingText.text = text;
        floatingText.fontSize = 30;
        floatingText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // Set the font to Arial
        floatingText.rectTransform.sizeDelta = new Vector2(400, floatingText.rectTransform.sizeDelta.y);

        ScoreFloat floatingTextScript = floatingTextObj.GetComponent<ScoreFloat>();
        Destroy(floatingTextObj, floatingTextScript.lifeTime);
    }




}


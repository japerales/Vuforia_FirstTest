using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointButton : MonoBehaviour {

    //points
    private int point = 500;
    private int[] points = { 500, 750, 1000, 1250, 2500, 5000 };
    private Text theText;
    private Image colour;
    //movement
    private float speed = 7f;
    private Animator g_anim;
    private string[] dance_triggers = { "m1", "m2", "m3", "m4" };

    // Use this for initialization
    void Start () {
        
        GameObject granny = GameObject.Find("UserDefinedTarget-1/Granny");
        g_anim = granny.GetComponent<Animator>();

        //points to text
        point = points[Random.Range(0,points.Length)];
        theText = GetComponentInChildren<Text>();
        theText.text = point.ToString();

        //speed
        float minValue = Mathf.Min((int)point + 2000, 5000);
        speed = (minValue/5000)*10f; //con point+1000 disminuimos 
        //la diferencia entre el valor menor y mayor. Usamos min para no pasarnos de 5000, por si sale 5000, que no sume 6000.
        colour = GetComponent<Image>();

        //Color change
        Color color = new Color((1/18)*speed, Mathf.Sin(speed * 4 * Mathf.Deg2Rad), 1 / speed * 7, 1);
        colour.color = color;

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SendCurrentPoints);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed, 0f, 0f);
	}

    void SendCurrentPoints()
    {
        ScoreManager.instance.AddScore((int)point);
        SpawnerScript.Instance.DeleteAllChildren();
        g_anim.SetTrigger(dance_triggers[Random.Range(0, dance_triggers.Length)]);
    }
}

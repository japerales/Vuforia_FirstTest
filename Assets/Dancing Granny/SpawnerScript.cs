using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : DefaultTrackableEventHandler {

    public RectTransform parent;
    // Use this for initialization
    public static SpawnerScript Instance;
    public GameObject InstructPanel;
    public bool isGamePlaying = false;
    private bool fired = false;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isTracked && !fired) //fired evita que se entre una y otra vez 
        {
            SpawnProcess();
            fired = true;
        }
        else if (!isTracked && fired) {
            fired = false;
            CancelInvoke();
        }
            
	}

    public void BeginProcess()
    {
        GameController.Instance.PlayMusic();
        InstructPanel.SetActive(false);
    }

    public void SpawnProcess() {

        InvokeRepeating("Spawn", 2.5f, 1.5f);
        isGamePlaying = true;
    }

    void Spawn() {
        GameObject x = Instantiate(Resources.Load("PointButton")) as GameObject;
        x.transform.SetParent(parent, false);
        x.transform.position = parent.position;
      
    }

    public void DeleteAllChildren()
    {
        foreach (Transform child in parent) //al parecer esto hace que se recorran todos los objetos hijos de este parent.
        {
            Destroy(child.gameObject);
        }
    }
}

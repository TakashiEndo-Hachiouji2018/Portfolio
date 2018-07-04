using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public GameObject kaishiButtons_;
    public GameObject mainCamera_;
    public GameObject camera_;
    public GameObject sceneBuild_;

    // Use this for initialization
    void Start ()
    {
        kaishiButtons_ = GameObject.Find("kaisiButton").GetComponent<TitleButtons>().gameObject;
        
        mainCamera_.GetComponent<Camera>().enabled = false;
        camera_.GetComponent<Camera>().enabled = true;

        mainCamera_.GetComponent<Chasing_Camera>().enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (sceneBuild_.GetComponent<SceneBuild>().currentscene == "Stage")
        {
            mainCamera_.GetComponent<Camera>().enabled = true;
            camera_.GetComponent<Camera>().enabled = false;
            this.gameObject.SetActive(false);

            mainCamera_.GetComponent<Chasing_Camera>().enabled = true;

        }
        else
        {
            camera_.GetComponent<Camera>().enabled = true;
            mainCamera_.GetComponent<Camera>().enabled = false;

            mainCamera_.GetComponent<Chasing_Camera>().enabled = false;
        }
    }
}

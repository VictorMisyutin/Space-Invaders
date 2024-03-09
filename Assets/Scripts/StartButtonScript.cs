using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GlobalVarsScript.shotCooldown = slider.value;
        SceneManager.LoadScene("MainScreen");
    }
}

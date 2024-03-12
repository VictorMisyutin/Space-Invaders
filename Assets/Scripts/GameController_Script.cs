using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_Script : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject redAlienPrefab;
    public GameObject greenAlienPrefab;

    public int score = 0;
    public int level = 1;
    
    public Text scoreTextField;
    private float horizontalSpan = 13f;
    private int numAliensPerRow = 13;
    private int numRows = 3;

    private int alienCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        float cd = GlobalVarsScript.shotCooldown;
        GameObject player = Instantiate(playerPrefab, new Vector3(0f, -5f, 0), Quaternion.identity);
        player.GetComponent<PlayerMovement>().SetShotCooldown(cd);
        LoadAliens();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadAliens()
    {
        for (float col = 0; col < horizontalSpan; col += horizontalSpan / numAliensPerRow)
        {
            for (int row = 0; row < numRows; row++)
            {
                if(level % 0 == 1)
                    Instantiate(redAlienPrefab, new Vector3((-horizontalSpan / 2) + col, 6 - row, 0), Quaternion.identity);
                else
                    Instantiate(greenAlienPrefab, new Vector3((-horizontalSpan / 2) + col, 6 - row, 0), Quaternion.identity);
                alienCount++;
            }
        }
    }
    public void AlienDestroyed(int points)
    {
        score += points;
        alienCount--;
        scoreTextField.text = score.ToString();
        if (alienCount == 0)
        {
            level++;
            LoadAliens();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pieces;
    private int pointsToWin;
    private int currentPoints;
    public bool gameWon;
    public GameObject slidingPieces;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update   
    void Start()
    {
        pointsToWin = pieces.transform.childCount;
        gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints >= pointsToWin)
        {
            pieces.SetActive(false);
            slidingPieces.SetActive(true);
            gameWon = true;
        }
    }

    public void addPoint()
    {
        currentPoints++;
    }

    public void subtractPoint()
    {
        currentPoints--;
    }

    


}

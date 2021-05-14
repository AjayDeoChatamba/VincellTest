using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject solvedState;
    private bool moving;
    

    private float startPosX;
    private float startPosY;
    public bool finishstate;
    private Vector3 resetPosition;

    //modification
    public bool inGameArea;
    public GameObject background;
    private BoxCollider2D bgCollider;


    
    private void Awake()
    {
        bgCollider = background.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.localPosition;
        
        inGameArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        //original under finish if
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }

        

        else if(!inGameArea)
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }

        
    }


    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        if(Mathf.Abs(this.transform.localPosition.x - solvedState.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - solvedState.transform.localPosition.y) <= 7.8f)
        {
            this.transform.position = new Vector3(solvedState.transform.position.x, solvedState.transform.position.y, solvedState.transform.position.z);
            GameObject.Find("gameManager").GetComponent<GameManager>().addPoint();
            finishstate = true;
        }

    }


    //modifications for new mechanic
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            inGameArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(inGameArea)
        {
            GameObject.Find("gameManager").GetComponent<GameManager>().subtractPoint();
            inGameArea = false;
            finishstate = false;
        }
        
    }
  
}

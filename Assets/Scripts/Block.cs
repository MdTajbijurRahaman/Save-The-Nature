using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public bool isActive = true;

    public int blockPositionX;
    public int blockPositionY;

    public int imagePositionX;
    public int imagePositionY;

    private SpliteManeger spliteManeger;

    private bool isClicked = false;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)&&isActive&&!isClicked)
        {
            isClicked = true;
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo)
            {
               
                if (hitInfo.transform.gameObject.name.Contains(gameObject.name)) {
                   
                    CheckSwaper(blockPositionX, blockPositionY);
                }
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }
        }

        if (Input.GetMouseButtonUp(0))
            isClicked = false;
        
    }


    public bool Match() {
        return blockPositionX == imagePositionX && blockPositionY == imagePositionY;
    }

    public void SetblockAxies(int i,int j,SpliteManeger spliteManeger) {
        blockPositionX = i;
        blockPositionY = j;
        this.spliteManeger = spliteManeger;
        

    }

    public void SetImageAxies(int i,int j,bool isColleder) {
        imagePositionX = i;
        imagePositionY = j;
        if(isColleder)
        gameObject.AddComponent<BoxCollider2D>();
    }


    void CheckSwaper(int i ,int j) {

        int upX = i;
        int upY = j + 1;

        int downX = i;
        int downY = j - 1;

        int leftX = i - 1;
        int leftY = j;

        int rightX = i + 1;
        int rightY = j;


        if (upY < spliteManeger.puzzleUnite && !spliteManeger.spriteRenderers[upX, upY].GetComponent<Block>().isActive) {

            Swaper(upX, upY);
        }
       else if (downY >=0 && !spliteManeger.spriteRenderers[downX, downY].GetComponent<Block>().isActive)
        {

            Swaper(downX, downY);
        }
       else if (leftX>=0 &&!spliteManeger.spriteRenderers[leftX, leftY].GetComponent<Block>().isActive)
        {

            Swaper(leftX, leftY);
        }
       else if (rightX < spliteManeger.puzzleUnite && !spliteManeger.spriteRenderers[rightX, rightY].GetComponent<Block>().isActive)
        {

            Swaper(rightX, rightY);

        }
    }

    private void Swaper(int xPosition ,int yPosition ) {
        spliteManeger.spriteRenderers[xPosition, yPosition].sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        spliteManeger.spriteRenderers[xPosition, yPosition].GetComponent<Block>().isActive = true;
        int imageX = spliteManeger.spriteRenderers[xPosition, yPosition].GetComponent<Block>().imagePositionX;
        int imageY = spliteManeger.spriteRenderers[xPosition, yPosition].GetComponent<Block>().imagePositionY;
        spliteManeger.spriteRenderers[xPosition, yPosition].GetComponent<Block>().SetImageAxies(imagePositionX, imagePositionY, false);
        isActive = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        imagePositionX = imageX;
        imagePositionY = imageY;

        UtilityManeger.currentStep++;
        spliteManeger.WinCheaker();
    }

}

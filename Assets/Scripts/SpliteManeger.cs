using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpliteManeger : MonoBehaviour {

    public SpriteRenderer block1;
    public UIMainGame uiMainGame;

    public Sprite puzzleSprite;

    public int puzzleUnite;

    public int [] puzzleSize;

    public Sprite[] puzzleSprites;

    public UIMainGame iMainGame;

    public SpriteRenderer[,] spriteRenderers;
    private SpriteRenderer[,] allSpriteRenderers;

    

    // Use this for initialization
    void Start () {
        puzzleSprite = puzzleSprites[UtilityManeger.currentLevel];
        puzzleUnite=puzzleSize[UtilityManeger.currentLevel];

        iMainGame.previewImage.sprite =puzzleSprites[UtilityManeger.currentLevel];
        iMainGame.previewButtonImage.sprite = puzzleSprites[UtilityManeger.currentLevel];
        BlockCreater(puzzleUnite);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void BlockCreater(int puzzleUnite) {
        spriteRenderers = new SpriteRenderer[puzzleUnite, puzzleUnite];
        allSpriteRenderers = new SpriteRenderer[puzzleUnite, puzzleUnite];

        Texture2D texture2D = puzzleSprite.texture;

        float horzonUnit=(texture2D.width/ puzzleSprite.pixelsPerUnit) /puzzleUnite;
        float verticalUnit = (texture2D.height/ puzzleSprite.pixelsPerUnit) / puzzleUnite;
       

        for (int i= 0; i<puzzleUnite;i++) {
            for (int j = 0; j < puzzleUnite; j++)
            {
             

                float xPosition = (i * horzonUnit) + block1.transform.position.x+ (i * .01f);
                float yPosition = (j * verticalUnit) + block1.transform.position.y + (j * .01f);
               

                SpriteRenderer spriteRenderer = Instantiate(block1, new Vector3(xPosition,yPosition , 0), block1.transform.rotation);
                spriteRenderer.gameObject.name = i + "," + j;
                spriteRenderer.GetComponent<Block>().SetblockAxies(i,j, this);
                spriteRenderers[i,j] = spriteRenderer;
                allSpriteRenderers[i, j] = spriteRenderer;

            }
        }
        
       
        Spliter(texture2D, allSpriteRenderers, puzzleUnite);
    }

    private void Spliter(Texture2D texture2D,SpriteRenderer [,] spriteRenderer,int puzzleUnite) {
       
        allSpriteRenderers = suffler(spriteRenderer);
       // allSpriteRenderers = spriteRenderer;

        for (int i=0;i<puzzleUnite;i++) {
            for (int j=0;j<puzzleUnite;j++) {
                Sprite tempSprite = Sprite.Create(texture2D, new Rect(i * (texture2D.width / puzzleUnite), j * (texture2D.height / puzzleUnite), texture2D.width / puzzleUnite, texture2D.height / puzzleUnite), new Vector2(0, 0), puzzleSprite.pixelsPerUnit);
                if (i == puzzleUnite - 1 && j == puzzleUnite - 1)
                {
                   
                    allSpriteRenderers[i, j].sprite = tempSprite;
                    allSpriteRenderers[i, j].GetComponent<Block>().isActive = false;
                    allSpriteRenderers[i, j].GetComponent<Block>().SetImageAxies(i, j, true);
                    allSpriteRenderers[i, j].sprite = null;
                }
                else {
                    allSpriteRenderers[i, j].sprite = tempSprite;
                    allSpriteRenderers[i, j].GetComponent<Block>().SetImageAxies(i,j,true);
                }
            }
        }
    }


    private SpriteRenderer[,] suffler(SpriteRenderer[,] spriteRenderers1) {
     

        int lengthRow = spriteRenderers1.GetLength(1);

        for (int i = spriteRenderers1.Length - 1; i > 0; i--)
        {
            int i0 = i / lengthRow;
            int i1 = i % lengthRow;

            int j = Random.Range(0,i + 1);
            int j0 = j / lengthRow;
            int j1 = j % lengthRow;

            SpriteRenderer temp = spriteRenderers1[i0, i1];
            spriteRenderers1[i0, i1] = spriteRenderers1[j0, j1];
            spriteRenderers1[j0, j1] = temp;
        }

        return spriteRenderers1;
    }



    public void WinCheaker() {

        foreach (SpriteRenderer spriteRenderer in spriteRenderers) {

            if (spriteRenderer.GetComponent<Block>().isActive&&!spriteRenderer.GetComponent<Block>().Match())
                return;
        }

        uiMainGame.WinPanelPopUpOpen();

    }

   

}

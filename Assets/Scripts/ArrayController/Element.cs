using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Element : MonoBehaviour
{
    public TextMeshProUGUI textBox; 
    private int value;
    public Sprite defaultSprite;
    public Sprite blueElement;
    public Sprite redElement;
    public Sprite greenElement;
    public Sprite yellowElement;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string text){
        textBox.text = text; 
    }

    public void setValue(int x){
        this.value = x;
    }

    public void setBlue(SpriteRenderer spriteRenderer){
        spriteRenderer.sprite = blueElement;
    }

    public void setRed(SpriteRenderer spriteRenderer){
        spriteRenderer.sprite = redElement;
    }

    public void setClear(SpriteRenderer spriteRenderer){
        spriteRenderer.sprite = defaultSprite;
    }

    public void setGreen(SpriteRenderer spriteRenderer){
        spriteRenderer.sprite = greenElement;
    }

    public void setYellow(SpriteRenderer spriteRenderer){
        spriteRenderer.sprite = yellowElement;
    }

    public int getValue(){
        return this.value;
    }

    public void delete(){
        Destroy(this.gameObject);
    }
}

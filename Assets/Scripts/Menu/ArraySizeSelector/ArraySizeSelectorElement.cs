using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArraySizeSelectorElement : MonoBehaviour
{
    private int value;
    public Sprite defaultSprite; 
    public Sprite blueElement;
    public Sprite greyElement;
    private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI textBox; 
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setValue(int x){
        this.value = x;
    }

    public void setClear(SpriteRenderer spriteRenderer){
        spriteRenderer.sprite = defaultSprite;
    }

    public void setBlue(SpriteRenderer spriteRenderer){
        spriteRenderer.sprite = blueElement;
    }

    public void setGrey(SpriteRenderer spriteRenderer){
        spriteRenderer.sprite = greyElement;
    }

    public int getValue(){
        return this.value;
    }

    public void delete(){
        Destroy(this.gameObject);
    }

    public void setText(string text){
        textBox.text = text; 
    }
    public void OnMouseOver()
    {
        setBlue(spriteRenderer);
        if (Input.GetMouseButtonDown(0)){
            setArraySize();
        }
    }

    public void OnMouseExit()
    {
        setClear(spriteRenderer);
    }

    public void setArraySize(){
        ArrayControllerRandom.setSize(this.value);
        Debug.Log(ArrayControllerRandom.getSize());
    }
}

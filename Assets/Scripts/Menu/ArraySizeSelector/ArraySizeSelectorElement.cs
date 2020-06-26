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
    public TextMeshProUGUI textBox; 
    public bool isSelected;

    public void setValue(int x){
        this.value = x;
    }

    public void setClear(){
        this.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    public void setBlue(){
        this.GetComponent<SpriteRenderer>().sprite = blueElement;
    }

    public void setGrey(){
        this.GetComponent<SpriteRenderer>().sprite = greyElement;
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
        if (!isSelected){
            setGrey();
        }
        if (Input.GetMouseButtonDown(0)){
           select(); 
           FindObjectOfType<ArraySizeController>().deselectOtherElement(value);
        }
    }

    public void OnMouseExit()
    {
        if(!isSelected){
            setClear();
        }
    }

    public void setArraySize(){
        ArrayControllerRandom.setSize(this.value);
    }

    public void deselect(){
        isSelected = false;
        setClear();
    }

    public void select(){
        setArraySize();
        setBlue();
        isSelected = true;
    }
}

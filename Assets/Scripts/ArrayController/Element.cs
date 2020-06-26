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

    public void setText(string text){
        textBox.text = text; 
    }

    public void setValue(int x){
        this.value = x;
    }

    public void setBlue(){
        this.GetComponent<SpriteRenderer>().sprite = blueElement;
    }

    public void setRed(){
        this.GetComponent<SpriteRenderer>().sprite = redElement;
    }

    public void setClear(){
        this.GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    public void setGreen(){
        this.GetComponent<SpriteRenderer>().sprite = greenElement;
    }

    public void setYellow(){
        this.GetComponent<SpriteRenderer>().sprite = yellowElement;
    }

    public int getValue(){
        return this.value;
    }

    public void delete(){
        Destroy(this.gameObject);
    }
}

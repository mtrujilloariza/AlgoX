using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSort : MonoBehaviour
{
    public ArrayControllerRandom arrayController;
    public float blinkSpeed;
    private int currentIndex = 0;
    private int minIndex = 0;
    private bool elementSelected = false;
    private int selectedIndex;
    private bool AllowUserControl;
    public bool repeat;

    // Start is called before the first frame update
    void Start()
    {
        arrayController.generateArray();
        AllowUserControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowUserControl == true){

        }
    }


    IEnumerator ResetInteration(){
        AllowUserControl = false;
        if (elementSelected == true){
            arrayController.setClear(arrayController.GetElement(selectedIndex));
            elementSelected = false;
        }
        for (int i = 0; i < 2; i++){
            arrayController.setRed(arrayController.GetElement(currentIndex));
            yield return new WaitForSeconds(blinkSpeed);
            arrayController.setClear(arrayController.GetElement(currentIndex));
            yield return new WaitForSeconds(blinkSpeed);
        }
        
        currentIndex = minIndex;
        AllowUserControl = true;
    }

    public bool CheckCorrectSwap(){
        if (elementSelected == false){
            if (arrayController.GetElement(minIndex).getValue() >= arrayController.GetElement(currentIndex).getValue()){
                return true;
            } else {
                return false;
            }
        } else {
            if (arrayController.GetElement(selectedIndex).getValue() > arrayController.GetElement(currentIndex).getValue()){
                return true;
            } else {
                return false;
            }
        }
    }

    public bool checkCorrectMin(){
        int[] array = arrayController.getValues();
        int minValue = array[selectedIndex];
        for(int i = minIndex; i < ArrayControllerRandom.getSize(); i++){
            if (minValue > array[i]){
                return false;
            }
        }
        return true;
    }

    public bool validMove(){
        if (arrayController.GetElement(selectedIndex).getValue() > arrayController.GetElement(currentIndex).getValue()){
            return false;
        }
        return true;
    }

    IEnumerator restartArray(){
        for (int i = 0; i < 2; i++){
            yield return new WaitForSeconds(blinkSpeed);
            foreach(Element e in arrayController.getArray()){
                arrayController.setClear(e);
            }
            yield return new WaitForSeconds(blinkSpeed);
            foreach(Element e in arrayController.getArray()){
                arrayController.setGreen(e);
            }
            yield return new WaitForSeconds(blinkSpeed);
            foreach(Element e in arrayController.getArray()){
                arrayController.setClear(e);
            }
        }    

        arrayController.deleteArray();
        yield return new WaitForSeconds(blinkSpeed);
        
        arrayController.generateArray();
        arrayController.fillArray();
        arrayController.setBlue(arrayController.GetElement(0));
        
        AllowUserControl = true;
        currentIndex = 0;
        minIndex = 0;
        selectedIndex = 0;
        yield return null;
    }
}


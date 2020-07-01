using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSortControllerRandom : MonoBehaviour
{
    public ArrayControllerRandom arrayController;
    public float blinkSpeed;
    private int currentIndex = 0;
    private int minIndex = 0;
    private bool elementSelected = false;
    private int selectedIndex;
    private bool AllowUserControl;
    public bool repeat;

    void Start()
    {
        arrayController.generateArray();
        arrayController.fillArray();
        inspectElement(0);
        AllowUserControl = true;
    }

    void Update()
    {
        if (AllowUserControl == true){
            if (minIndex < ArrayControllerRandom.getSize() - 1){
                if (Input.GetKeyDown("right")){
                    moveRight();
                }
                if (Input.GetKeyDown("down")){
                    SelectCurrentElement();
                }
            } else {
                setCorrect(minIndex);
                AllowUserControl = false;
                if(repeat){
                    StartCoroutine(restartArray());
                }
            }
        }
    }

    public void moveRight(){
        if(elementSelected == true && validMove()){
            if (selectedIndex != currentIndex){
                deselectElement(currentIndex);
            }
            LastElementSwapCheck();
            inspectElement(currentIndex);
        } else {
            StartCoroutine(ResetInteration());
        }

    }

    public void SelectCurrentElement(){
        if (CheckCorrectSwap()){
            selectElement(currentIndex);
            if (elementSelected == false){
                elementSelected = true;
            } else {
                deselectElement(selectedIndex);
            }
            selectedIndex = currentIndex;
        } else {
            StartCoroutine(ResetInteration());
        }
    }

    IEnumerator ResetInteration(){
        AllowUserControl = false;
        if (elementSelected == true){
            deselectElement(selectedIndex);
            elementSelected = false;
        }
        for (int i = 0; i < 2; i++){
            setWrong(currentIndex);
            yield return new WaitForSeconds(blinkSpeed);
            deselectElement(currentIndex);
            yield return new WaitForSeconds(blinkSpeed);
        }
        
        currentIndex = minIndex;
        inspectElement(currentIndex);

        AllowUserControl = true;
    }

    public void LastElementSwapCheck(){
        if (currentIndex == (ArrayControllerRandom.getSize() - 1)){
            if (!checkCorrectMin()){
                StartCoroutine(ResetInteration());
                return;
            }
            arrayController.swap(minIndex, selectedIndex);
            setCorrect(minIndex);

            minIndex++;
            currentIndex = minIndex;
            elementSelected = false;
            
        } else {
            currentIndex++;
        }
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
        inspectElement(0);
        
        AllowUserControl = true;
        currentIndex = 0;
        minIndex = 0;
        selectedIndex = 0;
        yield return null;
    }

    public void inspectElement(int index){
        arrayController.GetElement(index).setBlue();
    }

    public void setCorrect(int index){
        arrayController.GetElement(index).setGreen();
    }

    public void deselectElement(int index){
        arrayController.GetElement(index).setClear();
    }
    
    public void selectElement(int index){
        arrayController.GetElement(index).setYellow();
    }

    public void setWrong(int index){
        arrayController.GetElement(index).setRed();
    }
}

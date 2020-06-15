using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSortController : MonoBehaviour
{
    public ArrayController arrayController;
    private int currentIndex = 0;
    private int minIndex = 0;
    private bool elementSelected = false;
    private int selectedIndex;
    private bool AllowUserControl;
    // Start is called before the first frame update
    void Start()
    {
        arrayController.generateArray();
        arrayController.fillArray();
        arrayController.setBlue(arrayController.GetElement(0));
        AllowUserControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowUserControl == true){
            if (minIndex < arrayController.arraySize - 1){
                if (Input.GetKeyDown("right")){
                    moveRight();
                }

                if (Input.GetKeyDown("down")){
                    SelectElement();
                }
            } else {
                arrayController.setGreen(arrayController.GetElement(minIndex));
                AllowUserControl = false;
            }
        }
    }

    public void moveRight(){
        if(elementSelected == true && validMove()){
            if (selectedIndex != currentIndex){
                arrayController.setClear(arrayController.GetElement(currentIndex));
            }
            LastElementSwapCheck();
            arrayController.setBlue(arrayController.GetElement(currentIndex));
        } else {
            StartCoroutine(ResetInteration());
        }

    }

    public void SelectElement(){
        if (CheckCorrectSwap()){
            if (elementSelected == false){
                elementSelected = true;
                arrayController.setYellow(arrayController.GetElement(currentIndex));
                selectedIndex = currentIndex;
            } else {
                arrayController.setYellow(arrayController.GetElement(currentIndex));
                arrayController.setClear(arrayController.GetElement(selectedIndex));
                selectedIndex = currentIndex;
            }
        } else {
            StartCoroutine(ResetInteration());
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
            yield return new WaitForSeconds(.5f);
            arrayController.setClear(arrayController.GetElement(currentIndex));
            yield return new WaitForSeconds(.5f);
        }
        
        currentIndex = minIndex;
        arrayController.setBlue(arrayController.GetElement(currentIndex));

        AllowUserControl = true;
    }

    public void LastElementSwapCheck(){
        if (currentIndex == (arrayController.arraySize - 1)){
            if (!checkCorrectMin()){
                StartCoroutine(ResetInteration());
                return;
            }
            arrayController.swap(minIndex, selectedIndex);
            arrayController.setGreen(arrayController.GetElement(minIndex));

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
        for(int i = minIndex; i < arrayController.arraySize; i++){
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSortController : MonoBehaviour
{
    public ArrayControllerRandom array;
    public float blinkSpeed;
    private int currentIndex = 1;
    private int compareIndex = 0;
    private int nextIndex = 2;
    private bool AllowUserControl;
    public bool repeat;

    void Start()
    {
        array.generateArray();
        array.fillArray();
        AllowUserControl = true;
        inspectElements(0, 1);
    }

    void Update()
    {
        if (AllowUserControl == true){
            if(Input.GetKeyDown("down")){
                if (validSwap()){
                    swap();
                } else {
                    StartCoroutine(showError());
                }
            } 

            if(Input.GetKeyDown("left")){
                if(validMove()){
                    compareNext();
                } else{
                    StartCoroutine(showError());
                }
            } 

            if(Input.GetKeyDown("right")){
                if(validPosition()){
                    if (!lastElementCheck()){
                        nextElement();
                    } else {
                        deinspect(currentIndex, compareIndex);
                        AllowUserControl = false;
                        if (repeat == true){
                            StartCoroutine(restartArray());
                        }
                    }
                } else {
                    StartCoroutine(showError());
                }
            }
        }
    }

    public void swap(){
        array.swap(currentIndex, compareIndex);
        compareIndex++;
        currentIndex--;
    }

    public bool validSwap(){
        if (array.getValue(currentIndex) >= array.getValue(compareIndex)){
            return false;
        }

        if (currentIndex < compareIndex) return false;

        return true;
    }

    IEnumerator showError(){
        AllowUserControl = false;
        setError(currentIndex, compareIndex);
        yield return new WaitForSeconds(blinkSpeed);
        deinspect(currentIndex, compareIndex);
        yield return new WaitForSeconds(blinkSpeed);
        setError(currentIndex, compareIndex);
        yield return new WaitForSeconds(blinkSpeed);
        deinspect(currentIndex, compareIndex);
        AllowUserControl = true;  
        inspectElements(currentIndex, compareIndex);  
    }

    public bool validMove(){
        if (currentIndex > compareIndex) return false;
        if (currentIndex == 0) return false;
        return true;
    }

    public void compareNext(){
        deinspect(currentIndex, compareIndex);
        compareIndex = currentIndex - 1;
        inspectElements(currentIndex, compareIndex);
    }

    public bool validPosition(){
        if (currentIndex < compareIndex){
            if (currentIndex != 0) return false;
        } else {
            if(array.getValue(currentIndex) < array.getValue(compareIndex)){
                return false;
            }
        }

        if (validMove()) return false;

        return true;
    }

    public void nextElement(){
        deinspect(currentIndex, compareIndex);
        currentIndex = nextIndex;
        nextIndex++;
        compareIndex = currentIndex - 1;
        inspectElements(currentIndex, compareIndex);
    }

    public bool lastElementCheck(){
        if (nextIndex == ArrayControllerRandom.getSize()) return true;
        return false;
    }

    IEnumerator restartArray(){
        for (int i = 0; i < 2; i++){
            yield return new WaitForSeconds(blinkSpeed);
            foreach(Element e in array.getArray()){
                array.setClear(e);
            }
            yield return new WaitForSeconds(blinkSpeed);
            foreach(Element e in array.getArray()){
                array.setGreen(e);
            }
            yield return new WaitForSeconds(blinkSpeed);
            foreach(Element e in array.getArray()){
                array.setClear(e);
            }
        }    

        array.deleteArray();
        yield return new WaitForSeconds(blinkSpeed);
        
        array.generateArray();
        array.fillArray();
        inspectElements(0, 1);

        currentIndex = 1;
        nextIndex = 2;
        compareIndex = 0;

        AllowUserControl = true;
        yield return null;
    }

    public void inspectElements(int x, int y){
        array.GetElement(x).setYellow();
        array.GetElement(y).setYellow();
    }

    public void setError(int x, int y){
        array.GetElement(x).setRed();
        array.GetElement(y).setRed();
    }

    public void deinspect(int x, int y){
        if (x < nextIndex){
            array.GetElement(x).setGreen();
        } else {
            array.GetElement(x).setClear();
        }
        if (y < nextIndex){
            array.GetElement(y).setGreen();
        } else {
            array.GetElement(y).setClear();
        }
    }
}


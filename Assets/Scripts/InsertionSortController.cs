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
    private bool elementSelected = false;
    private int selectedIndex;
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
            if(Input.GetKeyDown("down") && validSwap()){
                swap();
            } else if(!validSwap()) {
                StartCoroutine(showError());
            }

            if(Input.GetKeyDown("left") && validMove()){
                compareNext();
            } else if (!validMove()){
                StartCoroutine(showError());
            }

            if(Input.GetKeyDown("right") && validPosition()){
                
            }
        }
    }

    public void swap(){
        array.swap(currentIndex, compareIndex);
        compareIndex++;
        currentIndex--;
    }

    public bool validSwap(){
        if (array.getValue(currentIndex) < array.getValue(compareIndex)){
            return true;
        }
        return false;
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
        return true;
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
        array.setBlue(array.GetElement(0));
        
        AllowUserControl = true;
        currentIndex = 1;
        nextIndex = 2;
        selectedIndex = 0;
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
        array.GetElement(x).setClear();
        array.GetElement(y).setClear();
    }
}


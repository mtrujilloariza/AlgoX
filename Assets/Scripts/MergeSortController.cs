using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSortController : MonoBehaviour
{
    public ArrayControllerRandom array;
    public ArrayControllerRandom arrayCopyLeft;
    public ArrayControllerRandom arrayCopyRight;
    public ArrayControllerRandom sortedArray;
    public float blinkSpeed;
    private int size = ArrayControllerRandom.getSize();
    private bool AllowUserControl = false;
    public bool repeat;
    private int i = 0; 
    private int j = 0; 
    private int k = 0;
    private int interationIndex = 0;
    private List<int> sections = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        array.generateArray();
        array.fillArray();
        setUpSections(0, array.size - 1);
        setUpMergeSort(sections[interationIndex], sections[interationIndex + 1]);
        AllowUserControl = true;
    }

    void Update(){
        if (AllowUserControl){
            if (i < arrayCopyLeft.size && j < arrayCopyRight.size){
                if (Input.GetKeyDown("left")){
                    if (leftIsMin()){
                        addElement(arrayCopyLeft.GetElement(i));
                        i++;
                        select(arrayCopyLeft, i);
                    } else {
                        StartCoroutine(showError());
                    }
                } else if (Input.GetKeyDown("right")){
                    if (!leftIsMin()){
                        addElement(arrayCopyRight.GetElement(j));
                        j++;
                        select(arrayCopyRight, j);
                    } else {
                        StartCoroutine(showError());
                    }
                } 
            } else if (i < arrayCopyLeft.size || j < arrayCopyRight.size) {
                if (i < arrayCopyLeft.size){
                    addElement(arrayCopyLeft.GetElement(i));
                    i++;
                } else if (j < arrayCopyRight.size){
                    addElement(arrayCopyRight.GetElement(j));
                    j++;
                }
            } else {
                AllowUserControl = false;
                if (interationIndex < sections.Count - 2){
                    StartCoroutine(finishInteration());
                } else {
                    StartCoroutine(resetArray());
                }
            }
        }
    }

    IEnumerator finishInteration(){
        for (int i = 0; i < 2; i++){
            foreach(Element e in sortedArray.getArray()){
                e.setGreen();
            }
            yield return new WaitForSeconds(blinkSpeed);
            foreach(Element e in sortedArray.getArray()){
                e.setClear();
            }
            yield return new WaitForSeconds(blinkSpeed);
        }
        copySubArray(0, sortedArray.size - 1, sortedArray, array, sections[interationIndex]);
        sortedArray.deleteArray();
        arrayCopyLeft.deleteArray();
        arrayCopyRight.deleteArray();
        i = 0;
        j = 0;
        k = 0;
        interationIndex += 2;
        setUpMergeSort(sections[interationIndex], sections[interationIndex + 1]);
        AllowUserControl = true;
    }

    IEnumerator resetArray(){

        copySubArray(0, sortedArray.size - 1, sortedArray, array, sections[interationIndex]);
        sortedArray.deleteArray();
        arrayCopyLeft.deleteArray();
        arrayCopyRight.deleteArray();

        for (int i = 0; i < 2; i++){
            foreach(Element e in array.getArray()){
                e.setGreen();
            }
            yield return new WaitForSeconds(blinkSpeed);
            foreach(Element e in array.getArray()){
                e.setClear();
            }
            yield return new WaitForSeconds(blinkSpeed);
        }
        array.deleteArray();

        if(repeat == true){
            i = 0;
            j = 0;
            k = 0;
            interationIndex = 0;
            ArrayControllerRandom.setSize(array.size);
            array.generateArray();
            array.fillArray();
            setUpMergeSort(sections[interationIndex], sections[interationIndex + 1]);
            AllowUserControl = true;
        }

    }

    public void setUpSections(int l, int r){
        if (l < r){
            int m = (l + r) / 2;
            setUpSections(l, m);
            setUpSections(m + 1, r);
            sections.Add(l);
            sections.Add(r);
        }
    }

    public void setUpMergeSort(int start, int end){
        disable(0, start);
        disable(end + 1, size);
        enable(start, end + 1);
        int mid = (end + start) / 2;

        setCopySize(mid - start + 1);
        arrayCopyLeft.generateArray();
        copySubArray(start, mid, array, arrayCopyLeft, 0);
        
        setCopySize(end - mid);
        arrayCopyRight.generateArray();
        copySubArray(mid + 1, end, array, arrayCopyRight, 0);

        setCopySize(end - start + 1);
        sortedArray.generateArray();
        sortedArray.clearLabels();
        select(arrayCopyLeft, 0);
        select(arrayCopyRight, 0);
    }

    public void setCopySize(int x){
        ArrayControllerRandom.setSize(x);
    }

    public void copySubArray(int index, int endIndex, ArrayControllerRandom array, ArrayControllerRandom arrayCopy, int copyStartIndex){
        int j = copyStartIndex; 
        for (int i = index; i <= endIndex; i++){
            arrayCopy.GetElement(j).setValue(array.GetElement(i).getValue());
            arrayCopy.GetElement(j).setText(array.GetElement(i).getValue().ToString());
            j++;
        }
    }

    public void addElement(Element e){
        StartCoroutine(addElementAnimation(e));
    }

    IEnumerator addElementAnimation(Element e){
        AllowUserControl = false;
        e.setBlue(); 
        yield return new WaitForSeconds(blinkSpeed);
        e.setClear();
        yield return new WaitForSeconds(blinkSpeed);
        e.setBlue(); 
        yield return new WaitForSeconds(blinkSpeed);
        e.setClear();
        sortedArray.GetElement(k).setText(e.getValue().ToString());
        sortedArray.GetElement(k).setValue(e.getValue());
        k++;
        AllowUserControl = true;
    }

    IEnumerator showError(){
        AllowUserControl = false;
        for (int l = 0; l < 2; l++){
            arrayCopyLeft.GetElement(i).setRed();
            arrayCopyRight.GetElement(j).setRed();
            yield return new WaitForSeconds(blinkSpeed);
            arrayCopyLeft.GetElement(i).setClear();
            arrayCopyRight.GetElement(j).setClear();
            yield return new WaitForSeconds(blinkSpeed);
        }
        select(arrayCopyLeft, i);
        select(arrayCopyRight, j);
        AllowUserControl = true;
    }

    public bool leftIsMin(){
        if(arrayCopyLeft.getValue(i) <= arrayCopyRight.getValue(j)){
            return true;
        }
        return false;
    }

    public void disable(int min, int max){
        for(int i = min; i < max; i++){
            array.GetElement(i).setGrey();
        }
    }

    public void enable(int min, int max){
        for(int i = min; i < max; i++){
            array.GetElement(i).setClear();
        }
    }

    public void select(ArrayControllerRandom array, int index){
        if (index < array.size){
             array.GetElement(index).setYellow();
        }
    }
}

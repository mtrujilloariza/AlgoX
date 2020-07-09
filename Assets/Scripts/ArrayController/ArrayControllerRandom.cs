using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayControllerRandom : MonoBehaviour
{
    public Element elementPrefab; 
    static int arraySize = 4;
    public int size;
    public int elementPadding;
    private Element[] array;
    public int min; 
    public int max;

    public void generateArray(){
        int x = (int) this.transform.position.x;
        int x2 = (int) this.transform.position.x;
        int mid = (arraySize - 1) / 2; 
        array = new Element[arraySize];
        size = arraySize;

        if (arraySize % 2 == 0){
            Element e;
            int j = 0;
            for(int i = 0; i < arraySize; i += 2){
                if (i == 0){
                    x += (elementPadding / 2);
                    x2 -= (elementPadding / 2);
                } else {
                    x += (elementPadding);
                    x2 -= (elementPadding);
                }   

                e = Instantiate(elementPrefab); 
                array[mid - j] = e;
                e.transform.position = new Vector2(x2, this.transform.position.y);

                e = Instantiate(elementPrefab);
                j++;
                array[mid + j] = e;
                e.transform.position = new Vector2(x, this.transform.position.y);

 
            }
            
        } else {

            Element e = Instantiate(elementPrefab);
            e.transform.position = new Vector2(x, this.transform.position.y);
            array[mid] = e;
            int j = 1;

            for (int i = 1; i < arraySize; i+=2){
                x += elementPadding;
                
                e = Instantiate(elementPrefab);
                array[mid + j] = e;
                e.transform.position = new Vector2(x, this.transform.position.y);

                e = Instantiate(elementPrefab);
                x2 -= elementPadding;
                array[mid - j] = e;
                e.transform.position = new Vector2(x2, this.transform.position.y);
                j++;
            }

        }
    }

    public void fillArray(){
        foreach(Element e in array){
            int num = Random.Range(min, max);
            e.setText(num.ToString());
            e.setValue(num);
        }
    }

    public void clearLabels(){
        foreach(Element e in array){
            e.setText("");
            e.setValue(0);
        }
    }

    public Element GetElement(int index){
        return array[index];
    }

    public void swap(int i, int j){
        Vector2 iVector = array[i].transform.position;
        Vector2 jVector = array[j].transform.position;

        array[i].transform.position = jVector;
        array[j].transform.position = iVector;

        Element temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public void setBlue(Element e){
        e.setBlue();
    }

    public void setRed(Element e){
        e.setRed();
    }

    public void setClear(Element e){
        e.setClear();
    }

    public void setGreen(Element e){
        e.setGreen();
    }

    public void setYellow(Element e){
        e.setYellow();
    }

    public int[] getValues(){
        int[] valueArray = new int[arraySize];
        for(int i = 0; i < arraySize; i++){
            valueArray[i] = this.array[i].getValue();
        }
        return valueArray;
    }

    public void deleteArray(){
        foreach(Element e in array){
            if (e != null){
                e.delete();
            }
        }
    }

    public Element[] getArray(){
        return array;
    }

    public static void setSize(int x){
        arraySize = x;
    }

    public static int getSize(){
        return arraySize;
    }

    public int getValue(int index){
        return array[index].getValue();
    }
}

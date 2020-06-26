using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraySizeController : MonoBehaviour
{
    public ArraySizeSelectorElement elementPrefab; 
    public int arraySize;
    public int elementPadding;
    private ArraySizeSelectorElement[] array;
    public int minValue;
    // Start is called before the first frame update
    void Start()
    {
        generateArray();
        fillArray();
        select(array[0]);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void generateArray(){
        int x = 0;
        int mid = (arraySize - 1) / 2; 
        array = new ArraySizeSelectorElement[arraySize];

        if (arraySize % 2 == 0){
            ArraySizeSelectorElement e;
            int j = 0;
            for(int i = 0; i < arraySize; i += 2){
                if (i == 0){
                    x += (elementPadding / 2);
                } else {
                    x += (elementPadding);
                }   

                e = Instantiate(elementPrefab); 
                array[mid - j] = e;
                e.transform.position = new Vector2(-x, this.transform.position.y);

                e = Instantiate(elementPrefab);
                j++;
                array[mid + j] = e;
                e.transform.position = new Vector2(x, this.transform.position.y);

 
            }
            
        } else {

            ArraySizeSelectorElement e = Instantiate(elementPrefab);
            e.transform.position = new Vector2(x, this.transform.position.y);
            array[mid] = e;
            int j = 1;

            for (int i = 1; i < arraySize; i+=2){
                x += elementPadding;
                
                e = Instantiate(elementPrefab);
                array[mid + j] = e;
                e.transform.position = new Vector2(x, this.transform.position.y);

                e = Instantiate(elementPrefab);
                array[mid - j] = e;
                e.transform.position = new Vector2(-x, this.transform.position.y);

                j++;
            }

        }
    }

    public void fillArray(){
        int i = minValue;
        foreach (ArraySizeSelectorElement e in array){
            e.setValue(i);
            e.setText(i.ToString());
            i++;
        }
    }

    public void deselectOtherElement(int newSelectedValue){
        foreach (ArraySizeSelectorElement e in array){
            if (e.isSelected && newSelectedValue != e.getValue()){
                e.deselect();
            }
        }
    }
    
    public void selectElement(int index){
        array[index].select();
    }

    public void select(ArraySizeSelectorElement e){
        e.setArraySize();
        e.setBlue();
        e.isSelected = true;
    }
}

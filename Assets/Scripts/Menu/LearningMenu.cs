using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LearningMenu : MonoBehaviour
{
    public static string scene;
    public void loadSelctionSort(){
        SceneManager.LoadScene("SelectionSort");
    }

    public void loadSelectionSortMenu(){
        SceneManager.LoadScene("SelectionSortMenu");
    }

    public void loadLearningMenu(){
        SceneManager.LoadScene("Learning Menu");
    }

    public void loadSizeSelector(){
        SceneManager.LoadScene("SizeSelector");
    }

    public void loadAlgoSim(){
        SceneManager.LoadScene(scene);
    }

    public void setAlgo(string scene){
        LearningMenu.scene = scene;
    }
    
}

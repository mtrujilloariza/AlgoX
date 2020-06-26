using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LearningMenu : MonoBehaviour
{
    public void loadSelctionSort(){
        SceneManager.LoadScene("SelectionSort");
    }

    public void loadSelectionSortMenu(){
        SceneManager.LoadScene("SelectionSortMenu");
    }

    public void loadLearningMenu(){
        SceneManager.LoadScene("Learning Menu");
    }
}

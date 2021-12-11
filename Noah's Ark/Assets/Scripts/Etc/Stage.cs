using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public Transform btnParent;
    private Button[] stageBtns;

    private void Start()
    {
        stageBtns = btnParent.GetComponentsInChildren<Button>();

        for (int i = 0; i < stageBtns.Length; i++)
        {
            int a = i;
            stageBtns[a].onClick.AddListener(() =>
            {
                //GameManager.Instance.Stage = a;
                SceneManager.LoadScene("InGame");
            });
        }
    }
}
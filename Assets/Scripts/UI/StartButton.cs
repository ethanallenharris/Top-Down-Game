using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : ButtonScript
{

    public GameObject sceneChanger;
    private void Start()
    {
        button.onClick.AddListener(ButtonClicked);
    }

    public virtual void ButtonClicked()
    {
        Debug.Log("Start pressed");
        sceneChanger.GetComponent<SceneChanger>().ChangeScene("SampleScene");
    }

}

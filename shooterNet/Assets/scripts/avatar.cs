using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avatar : MonoBehaviour {

    // Use this for initialization
    public string val = "";
    int indx,ind;
    void Start()
    {

        GetComponent<Dropdown>().RefreshShownValue();
        int indx = GetComponent<Dropdown>().value;
        GetComponent<Dropdown>().onValueChanged.AddListener(delegate
        {
            selectvalue(GetComponent<Dropdown>());
        });

    }
    private void selectvalue(Dropdown gdropdown)
    {

    }
    // Update is called once per frame
    void Update () {

        avatarin();
//        if (indx != ind) Destroy(gameObject);
    }
    public void avatarin()
    {
        GetComponent<Dropdown>().RefreshShownValue();
         ind = GetComponent<Dropdown>().value;
       // Debug.Log("col ind: " + ind);

        List<Dropdown.OptionData> opt = GetComponent<Dropdown>().options;
         val= opt[ind].text;
        playercontrol.playerColor(val);
//        Destroy(gameObject);
        Debug.Log("col val: " + val);
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }
    public void show()
    {
        gameObject.SetActive(false);
    }



    


    
    

}

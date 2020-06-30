using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class gamedata
{

    private int scored;

    public gamedata(int sc)
    {
        scored = sc;
    }

    public int getscore()
    {
        return scored;
    }

    public void setscore(int scc)
    {
        scored = scc;
    }
}

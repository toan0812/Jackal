using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBack : MonoBehaviour
{
    private bool isFirtUpdate = true;
    private void Update()
    {
        if (isFirtUpdate)
        {
            isFirtUpdate = false;
            Loader.LoaderCallBack();
        }
    }
}

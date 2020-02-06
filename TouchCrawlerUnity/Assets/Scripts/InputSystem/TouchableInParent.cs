using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableInParent : MonoBehaviour, ITouchable
{
    public IEvent GetEvent()
    {
        ITouchable parentTouchable = GetTouchable(transform.parent);
        return parentTouchable?.GetEvent();
    }

    private ITouchable GetTouchable(Transform transform)
    {
        if(transform == null)
        {
            return null;
        }
        var output = transform.GetComponent<ITouchable>();
        if(output != null)
        {
            return output;
        }
        else
        {
            return GetTouchable(transform.parent);
        }
    }
}
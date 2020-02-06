using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILatch
{
    bool Set();
    bool Reset();
    bool IsSet();
    void Trip();
}
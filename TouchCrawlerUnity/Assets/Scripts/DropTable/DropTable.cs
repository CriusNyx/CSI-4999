﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropTable", menuName = "DropTable")]
public class DropTable : ScriptableObject
{
    public DropTableSlot[] items;
}
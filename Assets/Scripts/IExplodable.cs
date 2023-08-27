using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplodable
{
    public event EventHandler<OnObjectExplodesEventArgs> OnObjectExplodes;
    public class OnObjectExplodesEventArgs : EventArgs
    {
        public Transform ObjectTransform;
    }
}

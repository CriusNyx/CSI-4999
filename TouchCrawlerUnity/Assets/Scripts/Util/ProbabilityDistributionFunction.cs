using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityDistributionFunction : IList<float>
{
    private List<float> pdf;
    private float[] cdf;

    public float Total
    {
        get
        {
            var cdf = GetCDF();
            return cdf[cdf.Length - 1];
        }
    }

    public ProbabilityDistributionFunction()
    {
        this.pdf = new List<float>();
    }

    public ProbabilityDistributionFunction(IEnumerable<float> data)
    {
        this.pdf = new List<float>(data);
    }

    public float this[int i]
    {
        get => pdf[i];
        set
        {
            pdf[i] = value;
            ClearCache();
        }
    }

    public int Count => pdf.Count;

    public bool IsReadOnly => ((IList<float>)pdf).IsReadOnly;

    private void ClearCache()
    {
        this.cdf = null;
    }

    private float[] GetCDF()
    {
        if(cdf == null)
        {
            cdf = new float[pdf.Count];
            float total = 0;
            for(int i = 0; i < pdf.Count; i++)
            {
                total += pdf[i];
                cdf[i] = total;
            }
        }
        return cdf;
    }

    public float GetCDF(int index)
    {
        return GetCDF()[index];
    }

    public int IndexOf(float item)
    {
        return ((IList<float>)pdf).IndexOf(item);
    }

    public void Insert(int index, float item)
    {
        ClearCache();
        ((IList<float>)pdf).Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        ClearCache();
        ((IList<float>)pdf).RemoveAt(index);
    }

    public void Add(float item)
    {
        ClearCache();
        ((IList<float>)pdf).Add(item);
    }

    public void Clear()
    {
        ClearCache();
        ((IList<float>)pdf).Clear();
    }

    public bool Contains(float item)
    {
        return ((IList<float>)pdf).Contains(item);
    }

    public void CopyTo(float[] array, int arrayIndex)
    {
        ((IList<float>)pdf).CopyTo(array, arrayIndex);
    }

    public bool Remove(float item)
    {
        ClearCache();
        return ((IList<float>)pdf).Remove(item);
    }

    public IEnumerator<float> GetEnumerator()
    {
        return ((IList<float>)pdf).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IList<float>)pdf).GetEnumerator();
    }

    public int Find(float targetValue)
    {
        float[] cdf = GetCDF();
        int index = Array.BinarySearch(cdf, targetValue);
        if(index < 0)
        {
            index = ~index; 
        }
        return index;
    }
}
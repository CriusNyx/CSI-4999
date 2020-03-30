using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedRandomSelector<T>
{
    List<T> elements = new List<T>();
    ProbabilityDistributionFunction pdf = new ProbabilityDistributionFunction();

    public WeightedRandomSelector()
    {

    }

    public WeightedRandomSelector(IEnumerable<(T, float)> data)
    {
        foreach (var (t, weight) in data)
        {
            Add(t, weight);
        }
    }

    public T this[int index] 
    { 
        get => elements[index]; 
        set => elements[index] = value; 
    }

    public int Count => elements.Count;

    public bool IsReadOnly => ((IList<T>)elements).IsReadOnly;

    public void Add(T t, float weight)
    {
        elements.Add(t);
        pdf.Add(weight);
    }

    //public void Add(T item)
    //{
    //    throw new System.NotImplementedException();
    //}

    public void Clear()
    {
        elements = new List<T>();
        pdf = new ProbabilityDistributionFunction();
    }

    public bool Contains(T item) => elements.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) => elements.CopyTo(array, arrayIndex);

    public IEnumerator<T> GetEnumerator() => elements.GetEnumerator();

    public int IndexOf(T item) => elements.IndexOf(item);

    public void Insert(int index, T item)
    {
        throw new System.NotImplementedException();
    }

    public bool Remove(T item)
    {
        int index = elements.IndexOf(item);
        if (index == -1)
        {
            return false;
        }
        else
        {
            RemoveAt(index);
            return true;
        }

    }

    public void RemoveAt(int index)
    {
        elements.RemoveAt(index);
        pdf.RemoveAt(index);
    }

    public T Select(float randomValue)
    {
        try
        {
            randomValue *= pdf.Total;
            return elements[pdf.Find(randomValue)];
        }
        catch
        {
            return default(T);
        }
    }
}
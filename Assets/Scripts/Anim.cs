using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Anim : MonoBehaviour
{

    public UnityEvent[] sequences;

    int _lastPlayed = -1;
    public int LastPlayed { get => _lastPlayed; }

    public void Play(int index)
    {
        if (sequences.Length <= index) {
            Debug.LogError("Yanlış index girdisi. Böyle bir sekans yok!");
            return;
        }
        _lastPlayed = index;
        sequences[index]?.Invoke();
    }

    public void Play()
    {
        Play(0);
    }
}

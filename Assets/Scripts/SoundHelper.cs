using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelper
{
    private static Dictionary<string, AudioClip> _soundMap =
    new Dictionary<string, AudioClip>() {
        { "default", Resources.Load<AudioClip>("sounds/a3") },
        { "a5", Resources.Load<AudioClip>("sounds/a5") },
        { "a-5", Resources.Load<AudioClip>("sounds/a-5") },
        { "b5", Resources.Load<AudioClip>("sounds/b5") },
        { "c5", Resources.Load<AudioClip>("sounds/c5") },
        { "c-5", Resources.Load<AudioClip>("sounds/c-5") },
        { "d5", Resources.Load<AudioClip>("sounds/d5") },
        { "d-5", Resources.Load<AudioClip>("sounds/d-5") },
        { "e5", Resources.Load<AudioClip>("sounds/e5") },
        { "f5", Resources.Load<AudioClip>("sounds/f5") },
        { "f-5", Resources.Load<AudioClip>("sounds/f-5") },
        { "g5", Resources.Load<AudioClip>("sounds/g5") },
        { "g-5", Resources.Load<AudioClip>("sounds/g-5") },
        { "a4", Resources.Load<AudioClip>("sounds/a4") },
        { "a-4", Resources.Load<AudioClip>("sounds/a-4") },
        { "b4", Resources.Load<AudioClip>("sounds/b4") },
        { "c4", Resources.Load<AudioClip>("sounds/c4") },
        { "c-4", Resources.Load<AudioClip>("sounds/c-4") },
        { "d4", Resources.Load<AudioClip>("sounds/d4") },
        { "d-4", Resources.Load<AudioClip>("sounds/d-4") },
        { "e4", Resources.Load<AudioClip>("sounds/e4") },
        { "f4", Resources.Load<AudioClip>("sounds/f4") },
        { "f-4", Resources.Load<AudioClip>("sounds/f-4") },
        { "g4", Resources.Load<AudioClip>("sounds/g4") },
        { "g-4", Resources.Load<AudioClip>("sounds/g-4") },
        { "a3", Resources.Load<AudioClip>("sounds/a3") },
        { "a-3", Resources.Load<AudioClip>("sounds/a-3") },
        { "b3", Resources.Load<AudioClip>("sounds/b3") },
        { "c3", Resources.Load<AudioClip>("sounds/c3") },
        { "c-3", Resources.Load<AudioClip>("sounds/c-3") },
        { "d3", Resources.Load<AudioClip>("sounds/d3") },
        { "d-3", Resources.Load<AudioClip>("sounds/d-3") },
        { "e3", Resources.Load<AudioClip>("sounds/e3") },
        { "f3", Resources.Load<AudioClip>("sounds/f3") },
        { "f-3", Resources.Load<AudioClip>("sounds/f-3") },
        { "g3", Resources.Load<AudioClip>("sounds/g3") },
        { "g-3", Resources.Load<AudioClip>("sounds/g-3") },
    };

    public static AudioClip GetAudioClip(string note)
    {
        if (_soundMap.ContainsKey(note)) {
            return _soundMap[note];
        }

        return _soundMap["default"];
    }
}

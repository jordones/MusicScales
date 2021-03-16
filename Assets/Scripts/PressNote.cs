using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressNote : MonoBehaviour
{
    private RepositionCamera _cameraScript;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject textContainer;
    public string _noteValue;
    private Scale _manager;
    private bool isRoot = false;
    private bool _isCorrect = false;

    public void Init(string note, bool correct, RepositionCamera cameraScript, AudioSource audioSource, Scale manager, bool root = false)
    {
        _noteValue = note;
        _cameraScript = cameraScript;
        _audioSource = audioSource;
        _manager = manager;
        _isCorrect = correct;
        name = note;
        isRoot = root;
        textContainer.GetComponent<TextMeshPro>().text = FormatNote(note);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);

        _audioSource.clip = SoundHelper.GetAudioClip(_noteValue);
        _audioSource.Play();

        if (isRoot) {
            return;
        }

        if (_isCorrect)
        {
            _cameraScript.EndPosition = gameObject.transform.position;
            isRoot = true;
            _manager.GenerateRound(transform.position);
        } else
        {
            Debug.Log("Oh no that's not right!");
        }

    }

    private string FormatNote(string note)
    {
        string formatted = note[0].ToString().ToUpper();
        if (note[1] == '-')
        {
            formatted += "#";
        }

        return formatted;
    }
}

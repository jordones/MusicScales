using UnityEngine;
using System.Collections.Generic;

public enum ScaleType {
    MAJOR,
    MINOR
}

public class Scale : MonoBehaviour
{
    [SerializeField]
    private GameObject notePrefab;
    [SerializeField]
    private AudioSource audioSource;

    private List<string> _progression;
    private string[] _allPossibleNotes =
    {   
        "a3",
        "a-3",
        "b3",
        "c3",
        "c-3",
        "d3",
        "d-3",
        "e3",
        "f3",
        "f-3",
        "g3",
        "g-3",
        "a4",
        "a-4",
        "b4",
        "c4",
        "c-4",
        "d4",
        "d-4",
        "e4",
        "f4",
        "f-4",
        "g4",
        "g-4",
        "a5",
        "a-5",
        "b5",
        "c5",
        "c-5",
        "d5",
        "d-5",
        "e5",
        "f5",
        "f-5",
        "g5",
        "g-5",
    };

    private RepositionCamera cameraScript;

    private int _index = 0;
    private const float VERTICAL_OFFSET = -2.5f;
    private const float HORIZONTAL_OFFSET = 1.5f;
    private Vector3 ROOT_NODE = new Vector3(0f, 3.5f, 0f);

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<RepositionCamera>();
        _progression = GenerateScale("c3", ScaleType.MAJOR);
        SpawnNode(ROOT_NODE, _progression[_index++], false, true);

        // Spawn L and R nodes
        GenerateRound(ROOT_NODE);
    }


    private Vector3 NodePosition(Vector3 rootPosition, bool left = false)
    {
        if (left)
        {
            return new Vector3(rootPosition.x - HORIZONTAL_OFFSET, rootPosition.y + VERTICAL_OFFSET, 0f);
        }

        return new Vector3(rootPosition.x + HORIZONTAL_OFFSET, rootPosition.y + VERTICAL_OFFSET, 0f);

    }

    private void SpawnNode(Vector3 position, string note, bool correct = false, bool root = false)
    {
        GameObject node = Instantiate(notePrefab, position, Quaternion.identity);
        node.GetComponent<PressNote>().Init(
            note,
            correct,
            cameraScript,
            audioSource,
            this,
            root
        );
    }

    public void GenerateRound(Vector3 rootPosition)
    {
        if (_index >= _progression.Count)
        {
            Debug.Log("Out of moves!");
            return;
        }

        // pick a side for the correct note
        bool left = Random.value >= 0.5f;

        string currentNote = _progression[_index++];

        // spawn left and right nodes
        SpawnNode(NodePosition(rootPosition, left), currentNote, true);
        SpawnNode(NodePosition(rootPosition, !left), GetRandomNote(currentNote));
    }

    private string GetRandomNote(string exclude)
    {
        string note = exclude;

        while (note[0] == exclude[0])
        {
            int newRandom = Random.Range(0, _allPossibleNotes.Length);
            note = _allPossibleNotes[newRandom];
        }

        return note;
    }

    private int[] GetScaleProgression(ScaleType scale)
    {
        switch (scale)
        {
            case ScaleType.MAJOR:
                return new int[] { 2, 2, 1, 2, 2, 2, 1 };
            case ScaleType.MINOR:
                return new int[] { 2, 1, 2, 2, 1, 2, 2 };
            default:
                return new int[] { };


        }

    }

    private List<string> GenerateScale(string homeNote, ScaleType scale)
    {
        int[] progression = GetScaleProgression(scale);
        List<string> noteList = new List<string>();
        if (scale == ScaleType.MAJOR)
        {
        }

        // get home key index
        int homeNoteIndex = 0;
        for(int i = 0; i < _allPossibleNotes.Length; i++)
        {
            if (_allPossibleNotes[i] == homeNote)
            {
                homeNoteIndex = i;
                break;
            }
        }


        noteList.Add(_allPossibleNotes[homeNoteIndex]);
        for (int j = 0; j < progression.Length; j++)
        {
            homeNoteIndex += progression[j];
            noteList.Add(_allPossibleNotes[homeNoteIndex]);
        }

        return noteList;
    }
}
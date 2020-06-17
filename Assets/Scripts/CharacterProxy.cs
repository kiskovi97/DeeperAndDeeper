using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class CharacterProxy : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;

    public GridGenerator generator;

    public bool Immortal = false;

    public TextMeshProUGUI scoreText;
    public BackgroundLight bLight;
    public TextMeshProUGUI lightText;

    // Start is called before the first frame update
    void Start()
    {
        var obj = Instantiate(ItemsContainer.Character);
        obj.transform.position = transform.position;

        mainCamera.Follow = obj.transform;

        var character = obj.GetComponent<Character>();
        character.Immortal = Immortal;
        character.scoreText = scoreText;
        character.lightText = lightText;
        character.bLight = bLight;


        if (generator != null)
        {
            generator.player = obj;
        }
    }
}

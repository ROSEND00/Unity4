using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 LastTapPosition;
    private Vector3 startRotation;

    public Transform topTransform;
    public Transform goalTransform;

    public GameObject helixLevelPrefab;

    public List<Stage> allStages = new List<Stage>();
    public float helixDistance;

    private List<GameObject> spawnedLevels = new List<GameObject>();



    private void Awake()
    {
        startRotation = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + .1f);
        LoadStage(0);

    }


   

    
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            Vector2 currentTapPosition = Input.mousePosition;
           
        if(LastTapPosition==Vector2.zero) {
                LastTapPosition = currentTapPosition;

            }
        float distance = LastTapPosition.x - currentTapPosition.x;
            LastTapPosition = currentTapPosition;


            transform.Rotate(Vector3.up * distance);
        
        }

        if(Input.GetMouseButtonUp(0)) {
        LastTapPosition=Vector2.zero;
        }
    }
    public void LoadStage(int stageNumber)
    {
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count - 1)];

        if (stage==null)
        {
            Debug.Log("No Stages");
            return;
        }
        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;
        
        FindObjectOfType<BallController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;

        transform.localEulerAngles = startRotation;

        foreach (GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        
        float levelDistance = helixDistance / stage.levels.Count;
        float spawPosY = topTransform.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawPosY -= levelDistance;
            GameObject level = Instantiate(helixLevelPrefab, transform);

            level.transform.localPosition = new Vector3(0, spawPosY, 0);
            spawnedLevels.Add(level);


            int partToDisable = 12 - stage.levels[i].partCount;
            List<GameObject> disableParts = new List<GameObject>();

            while (disableParts.Count<partToDisable) {

                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
               if( !disableParts.Contains(randomPart))
                randomPart.SetActive(false);
                disableParts.Add(randomPart);
            }


            List<GameObject> leftParts = new List<GameObject>();

            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;
                if (t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }
                
            }

            List<GameObject> deathparts =new List<GameObject>();

            while (deathparts.Count < stage.levels[i].deathPartCount)
            {
                GameObject randompart = leftParts[(Random.Range(0, leftParts.Count))];

                if (!deathparts.Contains(randompart))
                {

                    randompart.gameObject.AddComponent<DeathPart>();
                    deathparts.Add(randompart);

                }
            
            
            }
        }

    }
}

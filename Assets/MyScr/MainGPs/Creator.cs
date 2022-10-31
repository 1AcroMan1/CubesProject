using System.Collections;
using UnityEngine;

public class Creator : MainGP
{
    [SerializeField] private GameObject thingToCreate;
    [SerializeField] private Transform startPos;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private float timeToCreate;
    private void Awake()
    {
        StartCoroutine(CreateInstance());
    }
    public void UIToCreator(float[] values)
    {
        //параметры изменятся не сразу, а только при создании следующего объекта
        speed = values[0];
        distance = values[1];
        timeToCreate = values[2];
    }
    private IEnumerator CreateInstance()
    {
        Debug.Log("Created");
        GameObject instantiated = Instantiate(thingToCreate, startPos);
        instantiated.GetComponent<ObjectMovement>().GetValues(speed, distance);
        yield return new WaitForSeconds(timeToCreate);
        StartCoroutine(CreateInstance());
    }
}

using UnityEngine;

public class ObjectMovement : MainGP
{
    [SerializeField] private Vector3 baseDirection = Vector3.forward;
    private float timeToDissapear = 0f;
    private float objSpeed = 0;
    public void GetValues(float speed, float distance)
    {
        objSpeed = speed;
        timeToDissapear = distance / speed;
    }
    private void Start()
    {
        Destroy(gameObject, timeToDissapear);//А по хорошему нужно сделать пулл объектов и перемещать их для лучшей оптимизации
    }
    private void Update()
    {
        MoveObj();
    }
    private void MoveObj()
    {
        transform.Translate(baseDirection*Time.deltaTime*objSpeed);
    }
}

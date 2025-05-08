using UnityEngine;

public class CubeMovement : IMovement
{
    private GameObject gameObject;
    private Vector3 movementDirection;
    public float MovementSpeed { get; }

    public CubeMovement(GameObject gameObject, float movementSpeed, Vector3 movementDirection)
    {
        this.gameObject = gameObject;
        MovementSpeed = movementSpeed;
        this.movementDirection = movementDirection;
    }
    
    public void ExecuteMovement()
    {
        gameObject.transform.Translate(movementDirection * (MovementSpeed * Time.deltaTime), Space.World);
    }
}

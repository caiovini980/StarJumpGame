using UnityEngine;

public interface IJumpable
{
    void Jump(Rigidbody2D rb, float jumpForce);

    Rigidbody2D GetRigidbody();
}

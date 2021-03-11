using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpable
{
    void Jump(Rigidbody2D rb, float jumpForce);
}

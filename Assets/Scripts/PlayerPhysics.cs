using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the physics (mainly its collisions) of a player.
/// </summary>
public class PlayerPhysics : MonoBehaviour
{
  private bool isGrounded = false;

  void Start()
  {
  }

  void Update()
  {
  }

  /// <summary>
  /// If the player is on the ground or in the air.
  /// </summary>
  public bool IsGrounded
  {
    get
    {
      return isGrounded;
    }
  }

  /// <summary>
  /// Reset the different member variables keeping track of the different physics state of the player.
  /// </summary>
  public void Reset()
  {
    isGrounded = false;
  }

  void OnCollisionEnter2D(Collision2D coll)
  {
    if (coll.gameObject.CompareTag("Ground")) isGrounded = true;
  }

  void OnCollisionStay2D(Collision2D coll)
  {
    if (coll.gameObject.CompareTag("Ground")) isGrounded = true;
  }

  void OnCollisionExit2D(Collision2D coll)
  {
    if (coll.gameObject.CompareTag("Ground")) isGrounded = false;
  }
}
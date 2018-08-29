using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
  public class Landing : Base
  {
    void updateCharacter()
    {
      trigger(StateController.Trigger.BackToNormal);
    }
  }
}

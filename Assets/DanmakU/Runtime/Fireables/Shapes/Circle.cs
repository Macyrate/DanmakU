using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanmakU.Fireables {

[Serializable]
public class Circle : Fireable {

  [SerializeField]
  Range _count;

  [SerializeField]
  Range _radius;

  public Range Count { 
      get { return _count;} 
      set { _count = value; } 
  }

  public Range Radius { 
      get { return _radius;} 
      set { _radius = value; } 
  }

  public Circle(Range count, Range radius) {
      Count = count;
      Radius = radius;
  }

  public override void Fire(DanamkuConfig state) {
      float radius = Radius.GetValue();
      int count = Mathf.RoundToInt(Count.GetValue());
      var rotation = state.Rotation.GetValue();
      for (int i = 0; i < count; i++) {
        var angle = rotation + i * (Mathf.PI * 2 / count);
        state.Position = state.Position + (radius * RotationUtil.ToUnitVector(angle));
        state.Rotation = rotation;
        Subfire(state);
      }
  }
}

}

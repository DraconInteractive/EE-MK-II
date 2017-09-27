/* Original code Copyright (c) 2013 ftvs[1]
   Modified code Copyright (c) 2016 Shane Celis[2]

   Original code posted here[3].
   This comment generated by code-cite[4].

   NOTE: Reworked to shake the UI Canvas.

   [1]: https://github.com/ftvs
   [2]: https://twitter.com/shanecelis
   [3]: https://gist.github.com/ftvs/5822103
   [4]: https://github.com/shanecelis/code-cite
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace SeawispHunter.MinibufferConsole {

public class UIShake : MonoBehaviour {

  // How long the object should shake for.
  public float shakeDuration = 0f;

  // Amplitude of the shake. A larger value shakes the camera harder.
  public float shakeAmount = 0.7f;

  private float originalScale;
  private CanvasScaler scaler;
  public AnimationCurve scaleHow;
  private float shakeStart;

  void Awake() {
    scaler = GetComponent<CanvasScaler>();
  }

  void OnEnable() {
    originalScale = scaler.scaleFactor;
    shakeStart = Time.time - shakeDuration;
  }

  public void Shake() {
    shakeStart = Time.time;
  }

  void Update() {
    var t = Time.time - shakeStart;
    if (t < shakeDuration && t > 0) {
      scaler.scaleFactor = originalScale + shakeAmount * scaleHow.Evaluate(t/shakeDuration);
    } else {
      //shakeDuration = 0f;
      scaler.scaleFactor = originalScale;
    }
  }
}

}

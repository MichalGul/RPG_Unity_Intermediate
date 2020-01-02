using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.SceneManagement
{
    

    public class Fader : MonoBehaviour
    {

        CanvasGroup canvasGroup;

        private void Start() {
            canvasGroup = GetComponent<CanvasGroup>();
            
            //StartCoroutine(FadeOutIn());
        }


        public IEnumerator FadeOutIn()
        {
            yield return FadeOut(3f); //czeka az FadeOut sie skonczy
            print("Faded out");
            yield return FadeIn(3f); //potem robi sie fade in
            print("Faded in");


        }

        public IEnumerator FadeOut(float time)
        {
            while(canvasGroup.alpha < 1) // alpha is not one
            {
                //moving alpha towars one alpha += deltaAlpha / time
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null; // wait for one frame
            }
        }

        public IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha > 0) // alpha is not one
            {
                //moving alpha towars one alpha += deltaAlpha / time
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null; // wait for one frame
            }
        }


    }

}
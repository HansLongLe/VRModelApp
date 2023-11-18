using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardMarker : MonoBehaviour
{
   [SerializeField] private Transform tip;
   [SerializeField] private int penSize = 5;

   private Renderer renderer;
   private Color[] colors;
   private float tipHeight;
   private RaycastHit touch;
   private Whiteboard Whiteboard;
   private Vector2 touchPos, lastTouchPos;
   private bool touchedLastFrame;
   private Quaternion lastTouchRot;
   
   private void Start()
   {
      renderer = tip.GetComponent<Renderer>();
      colors = Enumerable.Repeat(renderer.material.color, penSize * penSize).ToArray();
      tipHeight = tip.localScale.y;
   }

   private void Update()
   {
      Draw();
   }

   private void Draw()
   {
      if (Physics.Raycast(tip.position, transform.up, out touch, tipHeight))
      {
         if (touch.transform.CompareTag("Whiteboard"))
         {
               if (Whiteboard == null)
               {
                  Whiteboard = touch.transform.GetComponent<Whiteboard>();
               }

               touchPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

               var x = (int)(touchPos.x * Whiteboard.textureSize.x - (penSize / 2));
               var y = (int)(touchPos.y * Whiteboard.textureSize.y - (penSize / 2));

               if (y < 0 || y > Whiteboard.textureSize.y || x < 0 || x > Whiteboard.textureSize.x) return;

               if (touchedLastFrame)
               {
                  Whiteboard.texture.SetPixels(x, y, penSize, penSize, colors);

                  for (float f = 0.01f; f < 1.00f; f+= 0.01f)
                  {
                     var lerpX = (int)Mathf.Lerp(lastTouchPos.x, x, f);
                     var lerpY = (int)Mathf.Lerp(lastTouchPos.y, y, f);
                     Whiteboard.texture.SetPixels(lerpX, lerpY,penSize, penSize, colors);
                  }

                  transform.rotation = lastTouchRot;
                  
                  Whiteboard.texture.Apply();
               }

               lastTouchPos = new Vector2(x, y);
               lastTouchRot = transform.rotation;
               touchedLastFrame = true;
               return;
         }
      }
      
      Whiteboard = null;
      touchedLastFrame = false;
   }
}

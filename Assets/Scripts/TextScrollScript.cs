using UnityEngine;
using UnityEngine.UI;

public class TextScrollScript : MonoBehaviour
{
  public string textToScroll;
  public float scrollSpeed = 25f;
  public bool begin;
	
  private RectTransform rectTransform;

  private void Start()
  {
    rectTransform = GetComponent<RectTransform>();
		
		
  }

  private void Update()
  {
    if (begin == true){
      rectTransform.position += Vector3.up * scrollSpeed * Time.deltaTime;
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCallTest : MonoBehaviour
{
    public RectTransform pic1;

    public RectTransform pic2;

    public Button lowDrawCallBtn;

    public Button hightDrawCallBtn;

    public int count;
    public float offset;
        
    private List<RectTransform> pic1List = new List<RectTransform>();
    private List<RectTransform> pic2List = new List<RectTransform>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < count; ++i)
        {
            var rt = Instantiate(pic1, transform);
            rt.gameObject.SetActive(true);
            
            pic1List.Add(rt);
        }
        
        for (var i = 0; i < count; ++i)
        {
            var rt = Instantiate(pic2, transform);
            rt.gameObject.SetActive(true);
            
            pic2List.Add(rt);
        }
        
        hightDrawCallBtn.onClick.AddListener((() =>
        {
            var pos = 0.0f;
            var index = 0;
            for (var i = 0; i < count; ++i)
            {
                var rt = pic1List[i];
                rt.SetSiblingIndex(index);
                rt.anchoredPosition = new Vector2(pos, 0);
                pos += offset;
                ++index;

                rt = pic2List[i];
                rt.SetSiblingIndex(index);
                rt.anchoredPosition = new Vector2(pos, 0);
                pos += offset;
                ++index;
            }
        }));
        
        lowDrawCallBtn.onClick.AddListener((() =>
        {
            var pos = 0.0f;
            var index = 0;
            for (var i = 0; i < count; ++i)
            {
                var rt = pic1List[i];
                rt.SetSiblingIndex(index);
                rt.anchoredPosition = new Vector2(pos, 0);
                pos += offset;
                ++index;
            }
            
            for (var i = 0; i < count; ++i)
            {
                var rt = pic2List[i];
                rt.SetSiblingIndex(index);
                rt.anchoredPosition = new Vector2(pos, 0);
                pos += offset;
                ++index;
            }
        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

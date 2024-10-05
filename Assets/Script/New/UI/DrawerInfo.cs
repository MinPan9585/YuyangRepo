using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerInfo : MonoBehaviour
{
    public List<string> MedInfo;
    public List<string> MedName;
    public List<string> symp;
    public Slider healBar;
    public Slider poisBar;
    public Slider tempBar;

    private StateManager stateManager;
    [SerializeField] private Text _MedInfo;
    [SerializeField] private Text _MedName;
    [SerializeField] private Text _symp;
    private float heal;
    private float pois;
    private float temp;
    private bool isMoved = false;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBarValue();
        if(stateManager.state == 1)
        {
            if (!isMoved)
            {
                LeanTween.moveLocalY(gameObject, 370, 1).setEaseInOutCubic();
                isMoved = true;
            }
            UpdateInfo();
        }
        else if (stateManager.state != 1 && isMoved)
        {
            LeanTween.moveLocalY(gameObject, 710, 1).setEaseInOutCubic();
            isMoved = false;
        }

    }

    private void UpdateInfo()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            #region compareTag
            if (hit.collider.name == "D1")
            {
                #region GetInfo
                _MedInfo.text = MedInfo[0];
                _MedName.text = MedName[0];
                _symp.text = hit.collider.GetComponent<BaseMed>().symps.ToString();
                heal = hit.collider.GetComponent<BaseMed>().cure;
                pois = hit.collider.GetComponent<BaseMed>().pois;
                temp = hit.collider.GetComponent<BaseMed>().temp;
                #endregion
            }
            else if (hit.collider.name == "D2")
            {
                #region GetInfo
                _MedInfo.text = MedInfo[1];
                _MedName.text = MedName[1];
                _symp.text = hit.collider.GetComponent<BaseMed>().symps.ToString();
                heal = hit.collider.GetComponent<BaseMed>().cure;
                pois = hit.collider.GetComponent<BaseMed>().pois;
                temp = hit.collider.GetComponent<BaseMed>().temp;
                #endregion
            }
            else if (hit.collider.name == "D3")
            {
                #region GetInfo
                _MedInfo.text = MedInfo[2];
                _MedName.text = MedName[2];
                _symp.text = hit.collider.GetComponent<BaseMed>().symps.ToString();
                heal = hit.collider.GetComponent<BaseMed>().cure;
                pois = hit.collider.GetComponent<BaseMed>().pois;
                temp = hit.collider.GetComponent<BaseMed>().temp;
                #endregion
            }
            else if (hit.collider.name == "D4")
            {
                #region GetInfo
                _MedInfo.text = MedInfo[3];
                _MedName.text = MedName[3];
                _symp.text = hit.collider.GetComponent<BaseMed>().symps.ToString();
                heal = hit.collider.GetComponent<BaseMed>().cure;
                pois = hit.collider.GetComponent<BaseMed>().pois;
                temp = hit.collider.GetComponent<BaseMed>().temp;
                #endregion
            }
            else if (hit.collider.name == "D5")
            {
                #region GetInfo
                _MedInfo.text = MedInfo[4];
                _MedName.text = MedName[4];
                _symp.text = hit.collider.GetComponent<BaseMed>().symps.ToString();
                heal = hit.collider.GetComponent<BaseMed>().cure;
                pois = hit.collider.GetComponent<BaseMed>().pois;
                temp = hit.collider.GetComponent<BaseMed>().temp;
                #endregion
            }
            else
            {
                #region GetInfo
                _MedInfo.text = MedInfo[5];
                _MedName.text = MedName[5];
                if (hit.collider.GetComponent<BaseMed>() != null)
                {
                    heal = hit.collider.GetComponent<BaseMed>().cure;
                    pois = hit.collider.GetComponent<BaseMed>().pois;
                    temp = hit.collider.GetComponent<BaseMed>().temp;
                    _symp.text = hit.collider.GetComponent<BaseMed>().symps.ToString();
                }
                #endregion
            }

            #endregion
        }
        else
            Debug.Log("");
    }

    private void UpdateBarValue()
    {
        healBar.value = heal;
        poisBar.value = pois;
        tempBar.value = temp;
    }
}

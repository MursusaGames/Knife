using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrainScrolling : MonoBehaviour
{
    [Header("Contollers")]
    [SerializeField, Range(0, 700)] private int panSpace;
    [SerializeField, Range(0f, 20f)] private float snapSpeed;
    [SerializeField, Range(0f, 5f)] private float scaleOffset;

    [Header("Other Objects")]
    [SerializeField] private GameObject brainPrefab;
    [SerializeField] private GameObject swipeHand;
    [SerializeField] private CustomPrefab panPrefab;
    [SerializeField] private CustomChoiceSystem customSystem;
    [SerializeField] private TMP_Text playerBrainNameText;
    [SerializeField] private TMP_Text bayBtnText;
    [SerializeField] private Image buyBtnImage;
    [SerializeField] private SubscribePanel panel;
    [SerializeField] private Image _currentPlayerSkin;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform _container;
    [SerializeField] private string buyBtnTitle = "BUY";


    private GameObject[] _instPans;
    private Vector2[] _panPos;
    private Vector2[] _panScale;
    private Vector2 _contentVector;
    private RectTransform _contentRect;
    private int _selectedPanID;
    private int _panCount;
    private bool _isScrolling;


    private void Start()
    {
        _panCount = 10;  //TODO изменить на количество страниц в скролле
        _panScale = new Vector2[_panCount];
        _contentRect = GetComponent<RectTransform>();
        _panPos = new Vector2[_panCount];
        _instPans = new GameObject[_panCount];

        for (int i = 0; i < _panCount; i++)
        {
            _instPans[i] = Instantiate(brainPrefab, transform, false);
            _instPans[i].GetComponent<Image>().sprite = customSystem.customsSprites[i];
            if (i == 0) continue;

            var tmpX = _instPans[i - 1].transform.localPosition.x + panPrefab.GetComponent<RectTransform>().sizeDelta.x + panSpace;
            _instPans[i].transform.localPosition = new Vector2(tmpX, _instPans[i].transform.localPosition.y);
            _panPos[i] = -_instPans[i].transform.localPosition;
        }

        var spriteIndex = PlayerPrefs.GetInt("PlayerSprites");
        var playerSkinName = PlayerPrefs.GetString("PlayerSkinName", panel.GetBrainName(0));

        UpdateCurrentPlayerSkin(spriteIndex);
        SetPlayerBrainText(playerSkinName);
    }


    private void FixedUpdate()
    {
        if (_isScrolling && !PlayerPrefs.HasKey("SwipeHelp"))
        {
            PlayerPrefs.SetString("SwipeHelp", "Used");
            swipeHand.SetActive(false);
        }

        if (!_isScrolling && (_contentRect.anchoredPosition.x >= _panPos[0].x || _contentRect.anchoredPosition.x <= _panPos[_panPos.Length - 1].x))
        {
            scrollRect.inertia = false;
        }


        float nearestPos = float.MaxValue;
        for (int i = 0; i < _panCount; i++)
        {
            float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _panPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                _selectedPanID = i;
            }

            float scale = Mathf.Clamp(1 / (distance / panSpace) * scaleOffset, .5f, 1f);
            _panScale[i].x = Mathf.SmoothStep(_instPans[i].transform.localScale.x, scale, 10 * Time.fixedDeltaTime);
            _panScale[i].y = Mathf.SmoothStep(_instPans[i].transform.localScale.y, scale, 10 * Time.fixedDeltaTime);
            _instPans[i].transform.localScale = _panScale[i];
        }

        float scrollVelosity = Mathf.Abs(scrollRect.velocity.x);

        if (scrollVelosity < 1000 && !_isScrolling)
            scrollRect.inertia = false;

        if (_isScrolling || scrollVelosity > 1000)
            return;

        _contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _panPos[_selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        _contentRect.anchoredPosition = _contentVector;
        UpgradePanel();
    }

    public void UpgradePanel()
    {
        if (0 <= _selectedPanID && 10 >= _selectedPanID)
        {
            panel.ShowPanel(_selectedPanID);

            if (_selectedPanID == PlayerPrefs.GetInt("PlayerSprites"))
            {
                bayBtnText.text = "CHOSEN";
                buyBtnImage.color = Color.gray;
                buyBtnImage.gameObject.GetComponent<Button>().interactable = false;
                SetPlayerBrainText(panel.GetBrainName(_selectedPanID));
                return;
            }

            buyBtnImage.color = Color.yellow;
            buyBtnImage.gameObject.GetComponent<Button>().interactable = true;

            bayBtnText.text = PlayerPrefs.HasKey("PlayerSprites") && 1 == PlayerPrefs.GetInt("id" + _selectedPanID.ToString()) ||
                PlayerPrefs.HasKey("PlayerSprites") && 0 == _selectedPanID ? "CHOICE" : buyBtnTitle;
        }
        else
            Debug.Log("Number out of range");
    }

    public void Scroll(bool scroll)
    {
        _isScrolling = scroll;

        if (scroll)
            scrollRect.inertia = true;
    }
    public void BuyBrainSkin()
    {
        customSystem.BuyBrain(_selectedPanID);
        UpdateCurrentPlayerSkin(_selectedPanID);
        SetPlayerBrainText(panel.GetBrainName(_selectedPanID));
    }

    public void SetPlayerBrainText(string name)
    {
        PlayerPrefs.SetString("PlayerSkinName", name);
        playerBrainNameText.SetText(name);
    }

    private void UpdateCurrentPlayerSkin(int spriteIndex)
    {
        _currentPlayerSkin.sprite = customSystem.customsSprites[spriteIndex];
    }


    public void ScrollRight()
    {
        int temp = 1153;
        if (_selectedPanID >= _panCount - 1)
            return;
        _container.anchoredPosition = new Vector2(_container.anchoredPosition.x - temp, _container.anchoredPosition.y);
    }

    public void ScrollLeft()
    {
        int temp = -1153;
        if (_selectedPanID <= 0)
            return;
        _container.anchoredPosition = new Vector2(_container.anchoredPosition.x - temp, _container.anchoredPosition.y);
    }


}

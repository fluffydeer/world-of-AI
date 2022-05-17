using System.Collections;
using UnityEngine;
using TMPro;

public class Tablet : MonoBehaviour
{
    public static Tablet Instance;       
    [SerializeField] TextMeshPro hintText;
    [SerializeField] GameObject firstPartOfTree;
    [SerializeField] GameObject secondPartOfTree;
    [SerializeField] GameObject canvas1;
    [SerializeField] GameObject canvas2;
    [SerializeField] GameObject canvas3;
    private AudioSource tabletAudio;
    public AudioClip correctAnswerSound;    
    private GameObject selectedAnswer;      //selected row on the tablet

    public void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        tabletAudio = GetComponent<AudioSource>();
    }

    public void SetSelectedAnswer(GameObject answer)
    {
        selectedAnswer = answer;
    }

    public void CheckAnswers(){
        //here the variables of the selected answers should be stored
        TabletInteraction tableInteractionScript = selectedAnswer.GetComponent<TabletInteraction>();
        bool isCorrect = tableInteractionScript.GetIsCorrect();
        if (isCorrect) {
            string question = selectedAnswer.GetComponent<TextMeshProUGUI>().text;
            tabletAudio.PlayOneShot(DecisionTreesLevelManager.Instance.successSound, 1.0f);

            if (question.Contains("Žlté")){
                ShowFirstTreePart();
            }
            else if(question.Contains("Zelené")){
                ShowSecondTreePart();
            }
        }
        else{
            WrongAnswerSelected(tableInteractionScript);
        }
    }

    private void ShowFirstTreePart(){
        firstPartOfTree.SetActive(true);
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    private void ShowSecondTreePart(){
        secondPartOfTree.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(true);
    }

    private void WrongAnswerSelected(TabletInteraction tableInteractionScript){
        tabletAudio.PlayOneShot(DecisionTreesLevelManager.Instance.failureSound, 1.0f);
        hintText.gameObject.SetActive(true);
        hintText.text = "Označ prvú otázku s najnižším gini indexom!";
        tableInteractionScript.SetHighlightColor(new Color32(255, 0, 0, 255));
        StartCoroutine(SetInactive(hintText.gameObject, 3f));
    }

    public IEnumerator SetActive(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(true);
    }

    public IEnumerator SetInactive(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(false);
    }
}

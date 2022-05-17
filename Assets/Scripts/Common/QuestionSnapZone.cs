using UnityEngine;

public class QuestionSnapZone : MonoBehaviour
{
    private bool notAnswered = true;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag(other.tag))
        {
            Answer answer = other.GetComponent<Answer>();
            if (answer && notAnswered)
            {
                notAnswered = false;
                answer.Destroy();
                if (DecisionTreesLevelManager.Instance)
                {
                    DecisionTreesLevelManager.Instance.PlayCorrectAnswerSound();

                }
                else if(NeuralNetworkManager.Instance)
                {
                    NeuralNetworkManager.Instance.PlayCorrectAnswerSound();
                }
                TestingArea.Instance.AddCorrectAnswerToCount();
                Destroy(gameObject);
            }
        }
    }
}

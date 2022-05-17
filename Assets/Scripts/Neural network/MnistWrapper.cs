using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace BarracudaSample
{
    public class MnistWrapper : MonoBehaviour
    {
        [SerializeField] Barracuda.NNModel nnModel = null;
        [SerializeField] Barracuda.BarracudaWorkerFactory.Type workerType = Barracuda.BarracudaWorkerFactory.Type.ComputePrecompiled;
        [SerializeField] List<RadialProgressBar> progressBars;

        Mnist mnist;

        bool isProcessing = false;

        void Start()
        {
            mnist = new Mnist(nnModel, workerType);
        }

        public void Execute(RenderTexture texture)
        {
            if (!isProcessing)
            {
                StartCoroutine(ExecuteAsync(texture));
            }
        }

        IEnumerator ExecuteAsync(Texture inputTex)
        {
            if (isProcessing)
            {
                yield break;
            }

            isProcessing = true;

            yield return mnist.ExecuteAsync(inputTex);

            var result = mnist.GetResult();

            for (int i = 0; i < result.Length; i++)
            {
                //we are sending the result into radial progress bar
                progressBars[i].SetProgressBar(i, 10 * result[i]);
            }
            isProcessing = false;
        }

        void OnDestroy()
        {
            mnist?.Dispose();
        }
    }
}

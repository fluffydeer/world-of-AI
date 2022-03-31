using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace BarracudaSample
{
    public class MnistSample : MonoBehaviour
    {
        [SerializeField] Barracuda.NNModel nnModel = null;
        [SerializeField] Text outputTextView = null;
        [SerializeField] Barracuda.BarracudaWorkerFactory.Type workerType = Barracuda.BarracudaWorkerFactory.Type.ComputePrecompiled;
        [SerializeField] List<RadialProgressBar> progressBars;

        Stopwatch stopwatch = new Stopwatch();
        Mnist mnist;

        bool isProcessing = false;

        void Start()
        {
            mnist = new Mnist(nnModel, workerType);
        }

        void OnDestroy()
        {
            mnist?.Dispose();
        }

        /// <summary>
        /// Invoked from LineDrawer
        /// </summary>
        /// <param name="texture"></param>
        public void Execute(RenderTexture texture)
        {
            UnityEngine.Debug.Log(texture);
            if (!isProcessing)
            {
                StartCoroutine(ExecuteAsync(texture));
            }
        }


        IEnumerator ExecuteAsync(Texture inputTex)
        {
            if (isProcessing)
            {
                UnityEngine.Debug.LogWarning("now processing");
                yield break;
            }

            isProcessing = true;

            stopwatch.Restart();
            yield return mnist.ExecuteAsync(inputTex);
            stopwatch.Stop();

            var result = mnist.GetResult();

            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //do radial progress baru by sme poslali result
                //na zaklade toho vysledku by zobrazilo adekvatne vyplneny kruh
                progressBars[i].SetProgressBar(i, 10 * result[i]);
                //cize ten string potom mozem vymazat
                sb.Append($"{i}: {result[i]:0.00}\n");
            }
            sb.AppendLine();
            sb.AppendLine($"execute time: {stopwatch.ElapsedMilliseconds} msec");

            outputTextView.text = sb.ToString();
            

            isProcessing = false;
        }

    }
}

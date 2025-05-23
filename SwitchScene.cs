using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SwitchScene : MonoBehaviour
{
    public Button startButton;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);//�����ٵ�ǰ����
        startButton.onClick.AddListener(onClik);
    }

    private void onClik()
    {
        StartCoroutine(LoadScene(1));//��ʼЭ�̼��س���
    }
    IEnumerator LoadScene(int index)
    {
        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);

        yield return new WaitForSeconds(1);//�ȴ�1��

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);//ʹ�ûص������������첽����
        asyncOperation.completed += OnLoadScene;//�첽������ɺ����OnLoadScene����
    }
    private void OnLoadScene(AsyncOperation obj)//�첽������ɺ���ô˺���
    {
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            //���ð�ť����
            startButton.gameObject.SetActive(false);
        }
    }
}

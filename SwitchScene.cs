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
        GameObject.DontDestroyOnLoad(this.gameObject);//不销毁当前对象
        startButton.onClick.AddListener(onClik);
    }

    private void onClik()
    {
        StartCoroutine(LoadScene(1));//开始协程加载场景
    }
    IEnumerator LoadScene(int index)
    {
        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);

        yield return new WaitForSeconds(1);//等待1秒

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);//使用回调函数来处理异步加载
        asyncOperation.completed += OnLoadScene;//异步加载完成后调用OnLoadScene函数
    }
    private void OnLoadScene(AsyncOperation obj)//异步加载完成后调用此函数
    {
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            //设置按钮隐藏
            startButton.gameObject.SetActive(false);
        }
    }
}

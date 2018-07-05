using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneBuild : MonoBehaviour
{
    //現在のシーンの所得
    public string currentscene;

    /*********Sceneの名前***********/
    //シーンを追加した場合ここに追加する。
    public enum Scenestate
    {
        TitleScene,
        BaseScene,
        GameScene,
    }
    public Scenestate Scene_state;
    /******************************/

    //変数
    string Title = "Title";
    string Game = "Stage";

    //trueがロード中,falseがロード中じゃない
    [SerializeField]
    private bool loadingScene = false;

    //ロードが終了したか
    private bool endload = false;

    //フェードの値
    private float fade_alpha;

    void Start()
    {
        BaseScene();
    }

    void Update()
    {
        currentscene = SceneManager.GetActiveScene().name;

        //タイトルシーン
        if (Scene_state == Scenestate.TitleScene)
        {
            TitleScene();
        }
        //ゲームシーン
        if (Scene_state == Scenestate.GameScene)
        {
            Gamescene();
            Debug.Log("Game");
        }
    }

    void BaseScene()
    {
        Scene_state = Scenestate.TitleScene;
    }

    //タイトルシーン
    public void TitleScene()
    {
        //同じ名前のシーンがあるか
        if (!ContainsScene(Title))
        {
            //なければ追加
            SceneManager.LoadSceneAsync(Title, LoadSceneMode.Additive);
        }

        //シーンのアクティブ化
        if (SceneActive(Title))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(Title));
        }
    }

    //ゲームシーン
    void Gamescene()
    {
        //同じ名前のシーンがあるか
        if (!ContainsScene(Game))
        {
            //なければ追加
            SceneManager.LoadSceneAsync(Game, LoadSceneMode.Additive);
        }

        //シーンのアクティブ化
        if (SceneActive(Game))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(Game));
        }
    }

    //次のシーンへ移動
    public void NextScene()
    {
        //タイトルシーンステートからゲームシーンステートへ
        if (Scene_state == Scenestate.TitleScene)
        {
            //シーンの追加
            //SceneManager.LoadSceneAsync(Game, LoadSceneMode.Additive);

            if (ContainsScene(Title))
            {
                //シーンのアンロード
                SceneManager.UnloadSceneAsync(Title);
            }

            //シーンステートをゲームシーン変更
            Scene_state = Scenestate.GameScene;
        }
        //ゲームシーンステートからリザルトシーンステートへ
        else if (Scene_state == Scenestate.GameScene)
        {
            //追加ではなく読み込みし直しをして初期化
            SceneManager.LoadScene("BaseScene");
        }
    }

    private void SceneDelete()
    {
        //自身以外のシーンを削除する保険
        if (Scene_state == Scenestate.TitleScene)
        {
            //シーンがあれば
            if (ContainsScene(Game))
            {
                //シーンのアンロード
                SceneManager.UnloadSceneAsync(Game);
            }
        }
        else if (Scene_state == Scenestate.GameScene)
        {
            //タイトルシーンがあれば
            if (ContainsScene(Title))
            {
                SceneManager.UnloadSceneAsync(Title);
            }
        }
    }

    // ゲーム内に同じ名前のシーンがあるか検索する//
    bool ContainsScene(string SceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == SceneName)
            {
                return true;
            }
        }
        return false;
    }

    //シーンのアクティブ化//
    //今アクティブになっているシーンの名前を確認してアクティブじゃなければアクティブにする
    bool SceneActive(string SceneName)
    {
        if (currentscene != SceneName)
        {
            return true;
        }
        return false;
    }
}

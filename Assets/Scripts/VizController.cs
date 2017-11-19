using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VizController : MonoBehaviour
{

    public GameObject XCubes;
    public GameObject YCubes;
    public GameObject Beam;
    public GameObject ColorBalls;
    public GameObject Shape_Square;
    public GameObject Shape_Circle;
    public GameObject Particles_1;
    public GameObject Particles_2;
    public GameObject Rainbow;
    public bool Randomize = true;
    public float randomTime = 10f;
    void Start()
    {
        InitRandomize();

    }

    void SpawnRainbow()
    {
        GameObject rainbow = Instantiate(Rainbow, transform.position, Quaternion.identity);
        rainbow.GetComponent<RainbowAnim>().InitShape(Utilities.RandomFloat(-2f, 2f), 30f);
    }
    void SpawnParticles_1()
    {
        GameObject part = Instantiate(Particles_1, transform.position, Quaternion.identity);
        part.GetComponent<ParticleController>().InitShape(Utilities.RandomFloat(-2f, 2f), 30f);
    }
    void SpawnParticles_2()
    {
        GameObject part = Instantiate(Particles_2, transform.position, Quaternion.identity);
        part.GetComponent<ParticleController>().InitShape(Utilities.RandomFloat(-2f, 2f), 30f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            CircleClockwise();
        if (Input.GetKeyDown(KeyCode.W))
            CircleCounterClock();
        if (Input.GetKeyDown(KeyCode.E))
            ClockPattern();
        if (Input.GetKeyDown(KeyCode.A))
            LeftRight();
        if (Input.GetKeyDown(KeyCode.S))
            RightLeft();
        if (Input.GetKeyDown(KeyCode.D))
            PosDownUp();
        if (Input.GetKeyDown(KeyCode.F))
            PosUpDown();
        if (Input.GetKeyDown(KeyCode.G))
            ScaleUpDown();
        if (Input.GetKeyDown(KeyCode.H))
            ScaleDownUp();
        if (Input.GetKeyDown(KeyCode.J))
            SpawnRainbow();
        if (Input.GetKeyDown(KeyCode.K))
            SpawnParticles_1();
        if (Input.GetKeyDown(KeyCode.L))
            SpawnParticles_2();
        if (Input.GetKeyDown(KeyCode.Z))
            InitBeamY();
        if (Input.GetKeyDown(KeyCode.X))
            InitBeamX();
        if (Input.GetKeyDown(KeyCode.C))
            InitColorBalls();
        if (Input.GetKeyDown(KeyCode.V))
            Init_Shape_Square_Anim1();
        if (Input.GetKeyDown(KeyCode.B))
            Init_Shape_Square_Anim2();
        if (Input.GetKeyDown(KeyCode.N))
            Init_Shape_Circle();
        if (Input.GetKeyDown(KeyCode.M))
        {
            InitRandomize();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Randomize = false;
            CancelInvoke("ChooseEffect");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            randomTime += 1;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            randomTime -= 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void InitRandomize()
    {
        Randomize = true;
        CancelInvoke("ChooseEffect");
        InvokeRepeating("ChooseEffect", 0f, randomTime);

    }

    void ChooseEffect()
    {
        int effect = Utilities.RandomInt(0, 25);
        switch (effect)
        {
            case 0:
                Init_Shape_Square_Anim1();
                break;
            case 1:
                Init_Shape_Square_Anim2();
                break;
            case 2:
                Init_Shape_Circle();
                break;
            case 3:
                InitColorBalls();
                break;
            case 4:
                InitBeamX();
                break;
            case 5:
                InitBeamY();
                break;
            case 6:
                CircleClockwise();
                break;
            case 7:
                CircleCounterClock();
                break;
            case 8:
                ClockPattern();
                break;
            case 9:
                LeftRight();
                break;
            case 10:
                RightLeft();
                break;
            case 11:
                PosDownUp();
                break;
            case 12:
                PosUpDown();
                break;
            case 13:
                ScaleDownUp();
                break;
            case 14:
                ScaleUpDown();
                break;
            case 15:
                InitBeamX();
                break;
            case 16:
                InitBeamY();
                break;
        }
    }

    void Init_Shape_Square_Anim1()
    {
        GameObject beam = Instantiate(Shape_Square, transform.position, Quaternion.identity);
        beam.GetComponent<Shape_Square>().InitShape(global::Shape_Square.SquareAnim.Anim1, Utilities.RandomFloat(.5f, 1.2f), 60f);
    }

    void Init_Shape_Square_Anim2()
    {
        GameObject beam = Instantiate(Shape_Square, transform.position, Quaternion.identity);
        beam.GetComponent<Shape_Square>().InitShape(global::Shape_Square.SquareAnim.Anim2, Utilities.RandomFloat(.5f, 1.2f), 60f);
    }
    void Init_Shape_Circle()
    {
        GameObject beam = Instantiate(Shape_Circle, transform.position, Quaternion.identity);
        beam.GetComponent<Shape_Circle>().InitShape(Utilities.RandomFloat(.5f, 1.2f), 45f);
    }
    void InitColorBalls()
    {
        GameObject beam = Instantiate(ColorBalls, transform.position, Quaternion.identity);
        beam.GetComponent<AnimateColor>().InitBalls(AnimateColor.ColorType.Normal, 1f, 10f);
    }

    void InitBeamX()
    {
        GameObject beam = Instantiate(Beam, transform.position, Quaternion.identity);
        beam.GetComponent<Beam>().InitBeam(global::Beam.BeamType.BeamX, Utilities.RandomFloat(0.5f, 1.5f), 10f);
    }
    void InitBeamY()
    {
        GameObject beam = Instantiate(Beam, transform.position, Quaternion.identity);
        beam.GetComponent<Beam>().InitBeam(global::Beam.BeamType.BeamY, Utilities.RandomFloat(0.5f, 1.5f), 10f);
    }

    void CircleClockwise()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.CircleClockwise,
            20f, 4f, 1f, 2f);
        newAnim.GetComponent<AnimateCubes>().SetupCircle();
    }

    void CircleCounterClock()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.CircleCounterClock,
            20f, 4f, 1f, 2f);
        newAnim.GetComponent<AnimateCubes>().SetupCircle();
    }

    void ClockPattern()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.Clock,
            20f, .15f, 1f, 10f);
        newAnim.GetComponent<AnimateCubes>().SetupCircle();
    }

    void LeftRight()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.LeftRight,
            20f, 4f, 1f, 5f);
        newAnim.GetComponent<AnimateCubes>().Setup_Adjust_StartingPos(new Vector3(-1.5f, -.8f, 0f), -1.5f, .2f);
    }

    void RightLeft()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.LeftRight,
            20f, -4f, 1f, 5f);
        newAnim.GetComponent<AnimateCubes>().Setup_Adjust_StartingPos(new Vector3(1.5f, -.8f, 0f), 1.5f, .2f);
    }
    void PosDownUp()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.PosDownUp,
            20f, 4f, 1f, 5f);
        newAnim.GetComponent<AnimateCubes>().Setup_Adjust_StartingPos(new Vector3(-1.5f, -.8f, 0f), .4f, -1f);
    }

    void PosUpDown()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.PosDownUp,
            20f, -4f, 1f, 5f);
        newAnim.GetComponent<AnimateCubes>().Setup_Adjust_StartingPos(new Vector3(-1.5f, .8f, 0f), .4f, 1f);
    }

    void ScaleDownUp()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.ScaleDownUp,
            20f, 3f, 1f, 5f);
        newAnim.GetComponent<AnimateCubes>().Setup_Adjust_StartingPos(new Vector3(-1.5f, -.8f, 0f), .4f, -1f);
    }

    void ScaleUpDown()
    {
        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.ScaleUpDown,
            20f, -3f, 1f, 5f);
        newAnim.GetComponent<AnimateCubes>().Setup_Adjust_StartingPos(new Vector3(-1.5f, .8f, 0f), .4f, 1f);
    }
}


using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class AdminDashboardBefore : MonoBehaviour
{
    // TimeScale, Seed, LogSim
    public TMP_InputField timeScale;
    public Slider timeScaleSlider;
    public TMP_InputField seed;
    public Toggle logSim;

    // Job Weights
    public TMP_InputField hunterWeight;
    public TMP_InputField gathererWeight;
    public TMP_InputField lumberjackWeight;
    public TMP_InputField builderWeight;

    // Villager Variables
    public TMP_InputField startingVillagers;
    public TMP_InputField moveSpeed;
    public TMP_InputField workSpeed;
    public TMP_InputField carryCapacity;
    public TMP_InputField hungerRate;
    public TMP_InputField vitalityPerFood;
    public TMP_InputField spawnTime;
    public TMP_InputField spawnCost;

    // Building Costs
    public TMP_InputField houseCost;
    public TMP_InputField outpostCost;

    // Resouce Quantity
    public TMP_InputField sheepFood;
    public TMP_InputField goatFood;
    public TMP_InputField berryFood;
    public TMP_InputField treeWood;

    // Resource Generation
    public TMP_InputField berryRespawnTime;
    public TMP_InputField forestSpacing;
    public TMP_InputField resourceDensity;
    public Slider resourceDensitySlider;
    public TMP_InputField perlinThreshold;
    public Slider perlinThresholdSlider;

    void Start()
    {
        // TimeScale, Seed, LogSim
        timeScale.text = SimVars.VARS.timeScale.ToString();
        timeScale.onEndEdit.AddListener((value) => SetTimescale(int.Parse(value)));
        timeScaleSlider.value = SimVars.VARS.timeScale;
        timeScaleSlider.onValueChanged.AddListener((value) => SetTimescale((int)value));
        seed.text = SimVars.VARS.seed.ToString();
        seed.onEndEdit.AddListener((value) => SimVars.VARS.seed = int.Parse(value));
        logSim.isOn = SimVars.VARS.logSim;
        logSim.onValueChanged.AddListener((value) => SimVars.VARS.logSim = value);

        // Job Weights
        hunterWeight.text = SimVars.VARS.hunterWeight.ToString();
        hunterWeight.onEndEdit.AddListener((value) => SimVars.VARS.hunterWeight = Mathf.Max(0, int.Parse(value)));
        gathererWeight.text = SimVars.VARS.gathererWeight.ToString();
        gathererWeight.onEndEdit.AddListener((value) => SimVars.VARS.gathererWeight = Mathf.Max(0, int.Parse(value)));
        lumberjackWeight.text = SimVars.VARS.lumberjackWeight.ToString();
        lumberjackWeight.onEndEdit.AddListener((value) => SimVars.VARS.lumberjackWeight = Mathf.Max(0, int.Parse(value)));
        builderWeight.text = SimVars.VARS.builderWeight.ToString();
        builderWeight.onEndEdit.AddListener((value) => SimVars.VARS.builderWeight = Mathf.Max(0, int.Parse(value)));

        // Villagers
        startingVillagers.text = SimVars.VARS.startingVillagers.ToString();
        startingVillagers.onEndEdit.AddListener((value) => SimVars.VARS.startingVillagers = Mathf.Max(1, int.Parse(value)));
        moveSpeed.text = SimVars.VARS.villagerMoveSpeed.ToString();
        moveSpeed.onEndEdit.AddListener((value) => SimVars.VARS.villagerMoveSpeed = Mathf.Max(0, float.Parse(value)));
        workSpeed.text = SimVars.VARS.villagerWorkSpeed.ToString();
        workSpeed.onEndEdit.AddListener((value) => SimVars.VARS.villagerWorkSpeed = Mathf.Max(0, float.Parse(value)));
        carryCapacity.text = SimVars.VARS.villagerCarryCapacity.ToString();
        carryCapacity.onEndEdit.AddListener((value) => SimVars.VARS.villagerCarryCapacity = Mathf.Max(1, int.Parse(value)));
        hungerRate.text = SimVars.VARS.villagerHungerRate.ToString();
        hungerRate.onEndEdit.AddListener((value) => SimVars.VARS.villagerHungerRate = Mathf.Max(0, float.Parse(value)));
        vitalityPerFood.text = SimVars.VARS.vitalityPerFood.ToString();
        vitalityPerFood.onEndEdit.AddListener((value) => SimVars.VARS.vitalityPerFood = Mathf.Max(0, float.Parse(value)));
        spawnTime.text = SimVars.VARS.villagerSpawnTime.ToString();
        spawnTime.onEndEdit.AddListener((value) => SimVars.VARS.villagerSpawnTime = Mathf.Max(0, float.Parse(value)));
        spawnCost.text = SimVars.VARS.villagerSpawnCost.ToString();
        spawnCost.onEndEdit.AddListener((value) => SimVars.VARS.villagerSpawnCost = Mathf.Max(0, int.Parse(value)));

        // Buildings
        houseCost.text = SimVars.VARS.houseBuildCost.ToString();
        houseCost.onEndEdit.AddListener((value) => SimVars.VARS.houseBuildCost = Mathf.Max(0, int.Parse(value)));
        outpostCost.text = SimVars.VARS.outpostBuildCost.ToString();
        outpostCost.onEndEdit.AddListener((value) => SimVars.VARS.outpostBuildCost = Mathf.Max(0, int.Parse(value)));

        // Resource Quantities
        sheepFood.text = SimVars.VARS.foodPerSheep.ToString();
        sheepFood.onEndEdit.AddListener((value) => SimVars.VARS.foodPerSheep = Mathf.Max(1, int.Parse(value)));
        goatFood.text = SimVars.VARS.foodPerGoat.ToString();
        goatFood.onEndEdit.AddListener((value) => SimVars.VARS.foodPerGoat = Mathf.Max(1, int.Parse(value)));
        berryFood.text = SimVars.VARS.foodPerBerry.ToString();
        berryFood.onEndEdit.AddListener((value) => SimVars.VARS.foodPerBerry = Mathf.Max(1, int.Parse(value)));
        treeWood.text = SimVars.VARS.woodPerTree.ToString();
        treeWood.onEndEdit.AddListener((value) => SimVars.VARS.woodPerTree = Mathf.Max(1, int.Parse(value)));

        berryRespawnTime.text = SimVars.VARS.berryRespawnTime.ToString();
        berryRespawnTime.onEndEdit.AddListener((value) => SimVars.VARS.berryRespawnTime = Mathf.Max(0, float.Parse(value)));
        forestSpacing.text = SimVars.VARS.resourceSpacing.ToString();
        forestSpacing.onEndEdit.AddListener((value) => SimVars.VARS.resourceSpacing = Mathf.Clamp(int.Parse(value), 4, 8));

        resourceDensity.text = SimVars.VARS.resourceDensity.ToString("F1");
        resourceDensity.onEndEdit.AddListener((value) => SetResourceDensity(float.Parse(value)));
        resourceDensitySlider.value = SimVars.VARS.resourceDensity;
        resourceDensitySlider.onValueChanged.AddListener((value) => SetResourceDensity(value));

        perlinThreshold.text = SimVars.VARS.perlinThreshold.ToString("F1");
        perlinThreshold.onEndEdit.AddListener((value) => SetPerlinThreshold(float.Parse(value)));
        perlinThresholdSlider.value = SimVars.VARS.perlinThreshold;
        perlinThresholdSlider.onValueChanged.AddListener((value) => SetPerlinThreshold(value));
    }

    private void SetTimescale(int value)
    {
        SimVars.VARS.timeScale = Mathf.Clamp(value, 0, 10);
        timeScale.text = SimVars.VARS.timeScale.ToString();
        timeScaleSlider.value = SimVars.VARS.timeScale;
    }

    private void SetResourceDensity(float value)
    {
        SimVars.VARS.resourceDensity = Mathf.Round(Mathf.Clamp01(value) * 10f) / 10f;
        resourceDensity.text = SimVars.VARS.resourceDensity.ToString("F1");
        resourceDensitySlider.value = SimVars.VARS.resourceDensity;
    }

    private void SetPerlinThreshold(float value)
    {
        SimVars.VARS.perlinThreshold = Mathf.Round(Mathf.Clamp01(value) * 10f) / 10f;
        perlinThreshold.text = SimVars.VARS.perlinThreshold.ToString("F1");
        perlinThresholdSlider.value = SimVars.VARS.perlinThreshold;
    }
}

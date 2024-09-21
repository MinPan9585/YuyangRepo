using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaHuangStat : medicineStats
{
    private Medicine medicine;
    [SerializeField] private List<string> MaHuangSymp;
    public override void Start()
    {
        base.Start();
        for (int i = 0; i < MaHuangSymp.Count; i++)
        {
            AddSymptom(MaHuangSymp[i]);

        }
    }

    public override void Update()
    {
        base.Update();
    }
}

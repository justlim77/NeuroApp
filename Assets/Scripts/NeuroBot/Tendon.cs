using UnityEngine;
using System.Collections;

[System.Serializable]
public class Tendon {

    //Tendon Type
    public enum TendonType {
        None,
        Tricep,
        Bicep,
        Supinator,
        Patellar,
        Ankle,
        Plantar
    };
    public TendonType tendonType = TendonType.None;

    //Deep Tendon Reflexes (DTR)
    //(+++) - Hyperactive
    //(++) - Normal
    //(+) - Sluggish
    //(-) - Absent
    public enum TendonReflex {
        Hyperactive,
        Normal,
        Sluggish,
        Absent
    };
    public TendonReflex tendonReflex = TendonReflex.Normal;

    //Default constructor
    public Tendon() { }
}

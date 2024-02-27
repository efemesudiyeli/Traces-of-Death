using UnityEngine;

[CreateAssetMenu(fileName = "WorkbenchCasesSO", menuName = "Detective/WorkbenchCasesSO", order = 0)]
public class WorkbenchCasesScriptableObject : ScriptableObject
{
    [SerializeField] public WorkbenchCase[] cases;
    [System.Serializable]
    public class WorkbenchCase
    {
        public string caseName;
        public string caseInfo;
        public Sprite caseSprite;
    }
}
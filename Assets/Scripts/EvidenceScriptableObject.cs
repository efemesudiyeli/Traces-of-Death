using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EvidenceSO", menuName = "Detective/EvidenceSO")]
public class EvidenceScriptableObject : ScriptableObject
{
    public EvidenceInfo evidenceInfo;

    [System.Serializable]
    public class EvidenceInfo
    {
        public EvidenceInfo(string evidenceName, string evidenceDescription, Sprite evidenceSprite)
        {
            this.evidenceName = evidenceName;
            this.evidenceDescription = evidenceDescription;
            this.evidenceSprite = evidenceSprite;
        }

        public string evidenceName;
        public string evidenceDescription;
        public Sprite evidenceSprite;
    }

}


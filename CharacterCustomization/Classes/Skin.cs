using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterCustomization.Classes
{
    public class Skin
    {
        public bool isMale { get; set; }
        public List<HeadOverlay> headOverlay { get; set; }
        public List<ComponentVariation> componentVariation { get; set; }
        public List<float> faceFeature { get; set; }
        public List<PropIndex> propIndex { get; set; }
        public int hairColor { get; set; }
        public int hairColor2 { get; set; }

        public Skin()
        {
            headOverlay = new List<HeadOverlay>();
            componentVariation = new List<ComponentVariation>();
            faceFeature = new List<float>();
            propIndex = new List<PropIndex>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CsbBuilder.BuilderNodes
{
    public class BuilderAisacNode : BuilderBaseNode
    {
        [Category("General"), DisplayName("Aisac Name")]
        [Description("Representative name of this aisac.")]
        public string AisacName { get; set; }

        [Category("General")]
        [Description("Type of this aisac. Values are unknown.")]
        public byte Type { get; set; }

        [Category("Graph")]
        public List<BuilderAisacGraphNode> Graphs { get; set; }

        public BuilderAisacNode()
        {
            Graphs = new List<BuilderAisacGraphNode>();
        }
    }
}

using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using PlanktonGh;
using Rhino.Geometry;

namespace Workshop
{
    public class GhcMeshGrowth : GH_Component
    {

        private MeshGrowthSystem myMeshGrowthSystem;

        /// <summary>
        /// Initializes a new instance of the GhcMeshGrowth class.
        /// </summary>
        public GhcMeshGrowth()
          : base(
                "MeshGrowth",
                "MeshGrowth",
                "Expand a mesh based on subdivition and avoiding self-collision",
                "Workshop",
                "MG")
        {
        }


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "Reset", "Reset", GH_ParamAccess.item);
            pManager.AddMeshParameter("Starting Mesh", "StartingMesh", "StartingMesh", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Subiteration Count", "Subiteration Count", "Subiteration Count", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Grow", "Grow", "Grow", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Max. Vertex Count", "Max. Vertex Count", "Max. Vertex Count", GH_ParamAccess.item);
            pManager.AddNumberParameter("Edge Length Constraint Weight", "Edge Length Constraint Weight", "Edge Length Constraint Weight", GH_ParamAccess.item);
            pManager.AddNumberParameter("Collision Distance", "Collision Distance", "Collision Distance", GH_ParamAccess.item);
            pManager.AddNumberParameter("Collision Weight", "Collision Weight", "Collision Weight", GH_ParamAccess.item);
            pManager.AddNumberParameter("Bending Resistance Weight", "Bending Resistance Weight", "Bending Resistance Weight", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Use R-Tree", "Use R-Tree", "Use R-Tree", GH_ParamAccess.item);
        }


        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "Mesh", "Mesh", GH_ParamAccess.item);
        }

        
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool iReset = true;
            Mesh iStartingMesh = null;
            int iSubiterationCount = 0;
            bool iGrow = false;
            int iMaxVertexCount = 0;
            double iEdgeLengthConstrainWeight = 0.0;
            double iCollisionDistance = 0.0;
            double iCollisionWeight = 0.0;
            double iBendingResistanceWeight = 0.0;
            bool iUseRTree = false;

            DA.GetData("Reset", ref iReset);
            DA.GetData("Starting Mesh", ref iStartingMesh);
            DA.GetData("Subiteration Count", ref iSubiterationCount);
            DA.GetData("Grow", ref iGrow);
            DA.GetData("Max. Vertex Count", ref iMaxVertexCount);
            DA.GetData("Edge Length Constraint Weight", ref iEdgeLengthConstrainWeight);
            DA.GetData("Collision Distance", ref iCollisionDistance);
            DA.GetData("Collision Weight", ref iCollisionWeight);
            DA.GetData("Bending Resistance Weight", ref iBendingResistanceWeight);
            DA.GetData("Use R-Tree", ref iUseRTree);


            if (iReset || myMeshGrowthSystem == null)
                myMeshGrowthSystem = new MeshGrowthSystem(iStartingMesh);

            myMeshGrowthSystem.Grow = iGrow;
            myMeshGrowthSystem.MaxVertexCount = iMaxVertexCount;
            myMeshGrowthSystem.EdgeLengthConstraintWeight = iEdgeLengthConstrainWeight;
            myMeshGrowthSystem.CollisionDistance = iCollisionDistance;
            myMeshGrowthSystem.CollisionWeight = iCollisionWeight;
            myMeshGrowthSystem.BendingResistanceWeight = iBendingResistanceWeight;
            myMeshGrowthSystem.UseRTree = iUseRTree;

            for (int i = 0; i < iSubiterationCount; i++)
                myMeshGrowthSystem.Update();

            DA.SetData("Mesh", myMeshGrowthSystem.GetRhinoMesh());
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                
                return null;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("090344a0-fb11-436c-8b50-c15e1abf8ed0"); }
        }
    }
}
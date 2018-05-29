using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Workshop
{
    public class GhcMovingParticle : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GhcMovingParticle class.
        /// </summary>
        public GhcMovingParticle()
          : base("Moving Particle", "Moving Particle",
              "Just move!",
              "Workshop", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "Reset", "Reset", GH_ParamAccess.item);
            pManager.AddVectorParameter("Velocity", "Velocity", "Velocity", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Particle", "Particle", "Particle", GH_ParamAccess.item);
        }



        Point3d currentPosition;


        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool iReset = false;
            DA.GetData("Reset", ref iReset);

            if (iReset){
                currentPosition = new Point3d(0, 0, 0);
            }
            else{
                Vector3d iVelocity = new Vector3d(0, 0, 0);
                DA.GetData("Velocity", ref iVelocity);
                currentPosition += iVelocity;
            }
            DA.SetData("Particle", currentPosition);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("1a8c787c-4136-49b4-b7b7-3a2560ff8e6e"); }
        }
    }
}
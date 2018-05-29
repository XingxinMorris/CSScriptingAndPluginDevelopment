using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Workshop
{
    public class GhcCreatePyramid : GH_Component
    {

        public GhcCreatePyramid()
          : base("Create Pyramid", "Pyramid",
              "Pyramid",
              "Workshop", "Subcategory")
        {
        }


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Base Plane", "Base Plane", "Base Plane", GH_ParamAccess.item);
            pManager.AddNumberParameter("Length", "Length", "Length", GH_ParamAccess.item);
            pManager.AddNumberParameter("Width", "Width", "Width", GH_ParamAccess.item);
            pManager.AddNumberParameter("Height", "Height", "Height", GH_ParamAccess.item);
        }


        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("Display Lines", "Display Lines", "Display Lines", GH_ParamAccess.list);

        }


        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Plane iBasePlane = Plane.WorldXY;
            double iLength = 1.0;
            double iHeight = 1.0;
            double iWidth = 1.0;

            DA.GetData("Base Plane", ref iBasePlane);
            DA.GetData("Width", ref iWidth);
            DA.GetData("Height", ref iHeight);
            DA.GetData("Length", ref iLength);

            Pyramid myPyramid = new Pyramid(iBasePlane, iLength, iWidth, iHeight);
            List<LineCurve> displayLines = myPyramid.ComputeDisplayLines();

            DA.SetDataList("Display Lines", displayLines);
            
        }


        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }


        public override Guid ComponentGuid
        {
            get { return new Guid("9de073fd-fd6a-4a07-9a4f-0fabba50c344"); }
        }
    }
}
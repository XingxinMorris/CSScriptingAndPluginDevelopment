﻿using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace Workshop
{
    public class MeshGrowthInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "MeshGrowth";
            }
        }
        public override Bitmap Icon
        {
            get
            {

                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("f5303522-73a6-4d58-aa4b-25134965f812");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
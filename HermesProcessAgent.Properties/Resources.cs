using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace HermesProcessAgent.Properties
{
    [CompilerGenerated]
    [DebuggerNonUserCode]
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    internal class Resources
    {
        private static ResourceManager resourceMan;

        private static CultureInfo resourceCulture;

        internal static Bitmap about
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("about", Resources.resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Resources.resourceCulture;
            }
            set
            {
                Resources.resourceCulture = value;
            }
        }

        internal static Bitmap exit
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("exit", Resources.resourceCulture);
            }
        }

        internal static Bitmap explorer
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("explorer", Resources.resourceCulture);
            }
        }

        internal static Bitmap H
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("H", Resources.resourceCulture);
            }
        }

        internal static Icon HermesPro
        {
            get
            {
                return (Icon)Resources.ResourceManager.GetObject("HermesPro", Resources.resourceCulture);
            }
        }

        internal static Icon HPA
        {
            get
            {
                return (Icon)Resources.ResourceManager.GetObject("HPA", Resources.resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(Resources.resourceMan, null))
                {
                    Resources.resourceMan = new ResourceManager("HermesProcessAgent.Properties.Resources", typeof(Resources).Assembly);
                }
                return Resources.resourceMan;
            }
        }

        internal Resources()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using TabBarTestApp.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace TabBarTestApp.iOS.CustomRenderers
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        public CustomTabbedPageRenderer() : base()
        {
            // Does not do anything?
            HidesBottomBarWhenPushed = true;
            TabBar.Hidden = true; // Leaves a blank space
        }

        public override void ViewWillAppear(bool animated)
        {
            
            TabBar.Frame = new CGRect(TabBar.Frame.X, TabBar.Frame.Y, TabBar.Frame.Width, 0); // Height is reset before being drawn to screen
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            nfloat TabBarHeight = TabBar.Frame.Height;
            Console.WriteLine(TabBarHeight);
        }

        public override UIView View
        {
            get
            {
                if (TabBar != null && TabBar.Frame.Height > 0)
                {
                    TabBar.Frame = new CGRect(TabBar.Frame.X, TabBar.Frame.Y, TabBar.Frame.Width, 0);
                }
                return base.View;
            }
        }
    }
}